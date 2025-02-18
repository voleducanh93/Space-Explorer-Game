using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;
	private bool isPaused = false;

	void Start()
	{
		pauseMenu.SetActive(false); 
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.SetActive(true);
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}
	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void Menu()
	{
		SceneManager.LoadSceneAsync("Main Menu"); 
		Time.timeScale = 1f;
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void Exit()
	{
		Application.Quit();
	}
}
