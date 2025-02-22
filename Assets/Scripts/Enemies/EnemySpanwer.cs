using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public List<GameObject> enemyPrefabs;

	private float waveDuration = 60f;
	private int smallEnemyCount = 15;
	private int bigEnemyCount = 15;

	private Coroutine waveCoroutine;
	private float maxSpawnRateInSeconds = 5f; 

	public void ScheduleNextEnemySpawner()
	{
		Invoke("StartSpawning", maxSpawnRateInSeconds);
	}

	private void StartSpawning()
	{
		if (waveCoroutine == null)
		{
			waveCoroutine = StartCoroutine(SpawnWave());
		}

		InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
	}

	public void UnScheduleNextEnemySpawn()
	{
		CancelInvoke("StartSpawning");
		CancelInvoke("IncreaseSpawnRate");

		if (waveCoroutine != null)
		{
			StopCoroutine(waveCoroutine);
			waveCoroutine = null;
		}
	}

	private IEnumerator SpawnWave()
	{
		float startTime = Time.time;

		yield return StartCoroutine(SpawnEnemyGroup(enemyPrefabs[0], smallEnemyCount, 20f));
		yield return StartCoroutine(SpawnEnemyGroup(enemyPrefabs[1], bigEnemyCount, 15f));
		yield return StartCoroutine(SpawnEnemyGroup(enemyPrefabs[2], 1, 40f));

		while (Time.time - startTime < waveDuration)
		{
			yield return null;
		}

		NextWave();
	}

	private IEnumerator SpawnEnemyGroup(GameObject enemyPrefab, int count, float duration)
	{
		float interval = duration / count;
		for (int i = 0; i < count; i++)
		{
			SpawnEnemy(enemyPrefab);
			yield return new WaitForSeconds(interval);
		}
	}

	private void SpawnEnemy(GameObject enemyPrefab)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject spawnedEnemy = Instantiate(enemyPrefab);
		spawnedEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}

	private void NextWave()
	{
		smallEnemyCount += 5;
		bigEnemyCount += 5;

		waveCoroutine = StartCoroutine(SpawnWave());
	}

	private void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
		{
			maxSpawnRateInSeconds--;
		}

		if (maxSpawnRateInSeconds == 1f)
		{
			CancelInvoke("IncreaseSpawnRate");
		}
	}
}
