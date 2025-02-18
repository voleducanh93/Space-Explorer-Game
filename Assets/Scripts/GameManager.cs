using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject playerShip;
	public GameObject asteroidSpawner;
	public GameObject starSpawner;
	public GameObject gameOverGO;
	public GameObject highScoreGO;
	public GameObject pauseMenuGO;

	public static GameManager Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	
	}
	public int GetCurrentLevel()
	{
		return PlayerPrefs.GetInt("CurrentLevel", 1); 
	}

	public enum GameManagerState
	{
		Gameplay,
		GameOver,
		Pause,
	}

	GameManagerState GMState;
	private bool isPaused = false;

	void Start()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!isPaused)
			{
				SetGameManagerState(GameManagerState.Pause);
			}
			else
			{
				ResumeGame();
			}
		}
	}

	void UpdateGameManagerState()
	{
		switch (GMState)
		{
			case GameManagerState.Gameplay:
				Time.timeScale = 1f;
				pauseMenuGO.SetActive(false);
				isPaused = false;

				playerShip.GetComponent<PlayerController>().Init();
				asteroidSpawner.GetComponent<AsteroidSpawner>().ScheduleNextAsteroidSpawner();
				starSpawner.GetComponent<StarSpawner>().ScheduleNextStarSpawner();

				break;
			case GameManagerState.GameOver:
				asteroidSpawner.GetComponent<AsteroidSpawner>().UnScheduleNextAsteroidSpawn();
				starSpawner.GetComponent<StarSpawner>().UnScheduleNextStarSpawn();

				gameOverGO.SetActive(true);

				highScoreGO.SetActive(true);
				ScoreManager.Instance.AddHighScore();

				break;
			case GameManagerState.Pause:
				Time.timeScale = 0f; 
				pauseMenuGO.SetActive(true);
				isPaused = true;
				break;
		}
	}

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState();
	}

	public void ResumeGame()
	{
		pauseMenuGO.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadSceneAsync("Main Menu");
	}
}
