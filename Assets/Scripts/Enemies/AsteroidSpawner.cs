using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject AsteroidGO;

	private float maxSpawnRateInSeconds = 5f;

	void SpawnAsteroid()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject anAsteroid = (GameObject)Instantiate(AsteroidGO);
		anAsteroid.transform.position = new Vector2(Random.Range(min.x, max.x), max.y + 5f);

		ScheduleNextAsteroidSpawn();
	}

	void ScheduleNextAsteroidSpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f)
		{
			spawnInNSeconds = Random.Range(2f, maxSpawnRateInSeconds);
		}
		else
			spawnInNSeconds = 1f;

		Invoke("SpawnAsteroid", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
	}

	public void ScheduleNextAsteroidSpawner()
	{
		Invoke("SpawnAsteroid", maxSpawnRateInSeconds);

		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}

	public void UnScheduleNextAsteroidSpawn()
	{
		CancelInvoke("SpawnAsteroid");
		CancelInvoke("IncreaseSpawnRate");
	}
}
