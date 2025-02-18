using UnityEngine;

public class StarSpawner : MonoBehaviour
{
	public GameObject StarGO;

	float maxSpawnRateInSeconds = 5f;
	void Start()
	{

	}

	void Update()
	{

	}

	void SpawnStar()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject aStar = (GameObject)Instantiate(StarGO);
		aStar.transform.position = new Vector2(Random.Range(min.x, max.x), max.y + 2f);

		ScheduleNextStarSpawn();
	}

	void ScheduleNextStarSpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f)
		{
			spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		}
		else
			spawnInNSeconds = 1f;

		Invoke("SpawnStar", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke("IncreaseSpawnRate");
	}

	public void ScheduleNextStarSpawner()
	{
		maxSpawnRateInSeconds = 5f;

		Invoke("SpawnStar", maxSpawnRateInSeconds);

		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}

	public void UnScheduleNextStarSpawn()
	{
		CancelInvoke("SpawnStar");
		CancelInvoke("IncreaseSpawnRate");
	}
}
