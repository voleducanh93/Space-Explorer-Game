using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
		PlayerPrefs.SetInt("CurrentLevel", levelId);
		PlayerPrefs.Save();

		string sceneName = "Scene " + levelId;
		SceneManager.LoadSceneAsync(sceneName);
	}
}
