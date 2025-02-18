using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance;

	public Sprite[] numberSprites;
	public Image[] scoreDigits;
	public Image[] highScoreDigits;

	private int score = 0;
	private int highScore = 0;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;

		highScore = PlayerPrefs.GetInt("HighScore", 0);
	}

	void Start()
	{
		UpdateScoreUI();
		UpdateHighScoreUI();
	}

	public void AddScore(int amount)
	{
		score += amount;
		UpdateScoreUI();
	}

	void UpdateScoreUI()
	{
		if (score < 0)
			score = 0;
		else
		{
			string scoreString = score.ToString("D5");

			for (int i = 0; i < scoreDigits.Length; i++)
			{
				int digit = int.Parse(scoreString[i].ToString());
				scoreDigits[i].sprite = numberSprites[digit];
			}
		}
	}

	void UpdateHighScoreUI()
	{
		string highScoreString = highScore.ToString("D5");

		for (int i = 0; i < highScoreDigits.Length; i++)
		{
			int digit = int.Parse(highScoreString[i].ToString());
			highScoreDigits[i].sprite = numberSprites[digit];
		}
	}

	public void AddHighScore()
	{

		if (score > highScore)
		{
			highScore = score;
			PlayerPrefs.SetInt("HighScore", highScore);
		}

		UpdateHighScoreUI();
	}

	public void ResetScore()
	{
		score = 0;
		UpdateScoreUI();
	}

}
