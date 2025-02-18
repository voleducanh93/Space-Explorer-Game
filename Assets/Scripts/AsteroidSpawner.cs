using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour
{
	public GameObject AsteroidGO;

	private float maxSpawnRateInSeconds = 5f;

	void Start()
	{
		string sceneName = SceneManager.GetActiveScene().name;

		if (int.TryParse(sceneName.Replace("Scene ", ""), out int levelId))
		{
			switch (levelId)
			{
				case 2:
					maxSpawnRateInSeconds = 2f;
					break;
				default:
					maxSpawnRateInSeconds = 5f;
					break;
			}
		}
	}

	void Update()
	{

	}

	void SpawnAsteroid()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject anAsteroid = (GameObject)Instantiate(AsteroidGO);
		anAsteroid.transform.position = new Vector2(Random.Range(min.x, max.x), max.y + 2.3f);

		ScheduleNextAsteroidSpawn();
	}

	void ScheduleNextAsteroidSpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 0.8f)
		{
			spawnInNSeconds = Random.Range(2f, maxSpawnRateInSeconds);
		}
		else
			spawnInNSeconds = 0.8f;

		Invoke("SpawnAsteroid", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 0.8f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 0.8f)
			CancelInvoke("IncreaseSpawnRate");
	}

	public void ScheduleNextAsteroidSpawner()
	{
		Invoke("SpawnAsteroid", maxSpawnRateInSeconds);

		InvokeRepeating("IncreaseSpawnRate", 0f, 20f);
	}

	public void UnScheduleNextAsteroidSpawn()
	{
		CancelInvoke("SpawnAsteroid");
		CancelInvoke("IncreaseSpawnRate");
	}
}
