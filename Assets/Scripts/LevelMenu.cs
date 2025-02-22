using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
		SceneManager.LoadSceneAsync("Scene 1");
	}
}
