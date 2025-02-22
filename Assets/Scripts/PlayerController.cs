using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject GameManagerGO;
	public GameObject PlayerBulletGO;
	public GameObject bulletPosition;
	public GameObject Expolosion;

	public int maxHealth = 3;
	public int health = 3;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	public int score = 0;
	public Text scoreText;

	public float speed;
	public float startMoveSpeed = 2f;
	private bool isMovingToStart;

	public float shootingCooldown = 0.2f; 
	private float nextFireTime = 0f;

	public void Init()
	{
		health = maxHealth;
		score = 0;
		UpdateScoreUI();
		transform.position = new Vector2(0, -Camera.main.orthographicSize);
		gameObject.SetActive(true);
		UpdateHeartsUI();

		isMovingToStart = true;

	}

	void Start()
	{
		Init();
	}

	void Update()
	{
		if (isMovingToStart)
		{
			MoveToStartPosition();
		}
		else
		{
			HandleInput();
		}
	}

	void HandleInput()
	{
		AudioSource audioSource = GetComponent<AudioSource>();

		if (Input.GetKeyDown("space") && Time.time >= nextFireTime)
		{
			audioSource.Play();
			Instantiate(PlayerBulletGO, bulletPosition.transform.position, Quaternion.identity);

			nextFireTime = Time.time + shootingCooldown;
		}

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
	
		Vector2 direction = new Vector2(x, y).normalized;
		Move(direction);

	}

	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		transform.position = pos;

		float tiltAngle = 20f;
		float targetRotation = -direction.x * tiltAngle; 

		float currentRotation = transform.eulerAngles.z;
		if (currentRotation > 180) currentRotation -= 360; 

		float smoothRotation = Mathf.Lerp(currentRotation, targetRotation, 5f * Time.deltaTime);
		transform.rotation = Quaternion.Euler(0, 0, smoothRotation);
	}

	void MoveToStartPosition()
	{
		Vector2 targetPosition = new Vector2(0, -3f); 
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, startMoveSpeed * Time.deltaTime);

		if ((Vector2)transform.position == targetPosition)
		{
			isMovingToStart = false; 
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "AsteroidSpawnerTag" || collision.tag == "EnemyShipTag" || collision.tag == "EnemyBulletTag")
		{
			ScoreManager.Instance.AddScore(-10);
			PlayExplosion();
			TakeDamage(1);
		}

		if (collision.tag == "BossShipTag" || collision.tag == "BossBulletTag")
		{
			ScoreManager.Instance.AddScore(-10);
			PlayExplosion();
			TakeDamage(3);
		}
	}
	void TakeDamage(int damge)
	{
		health = Mathf.Max(0, health - damge);
		UpdateHeartsUI();

		if (health == 0)
		{
			GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
			gameObject.SetActive(false);
		}
	}

	void UpdateHeartsUI()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			hearts[i].sprite = i < health ? fullHeart : emptyHeart;
		}
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate(Expolosion);
		explosion.transform.position = transform.position;
	}

	void UpdateScoreUI()
	{
		if (scoreText != null)
			scoreText.text = "Score: " + score.ToString("D5");
	}

	public void AddScore(int amount)
	{
		score += amount;
		UpdateScoreUI();
	}
}
