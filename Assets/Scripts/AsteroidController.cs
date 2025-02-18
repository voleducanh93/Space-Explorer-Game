using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;

public class AsteroidController : MonoBehaviour
{
	public GameObject AsteroidExpolosion;
	public int health;
	private AudioSource audioSource;
	

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();

		int currentLevel = GameManager.Instance.GetCurrentLevel();

		if (currentLevel == 1)
		{
			health = 3;
		}
		else if (currentLevel == 2)
		{
			health = 6;
			transform.localScale = new Vector3(1.2f, 1.2f, 1f); 
		}
	}

	private void Update()
	{
		MoveAsteroid();
		CheckBounds();
	}

	private void MoveAsteroid()
	{
		Vector2 position = transform.position;
		position = new Vector2(position.x, position.y - 2f * Time.deltaTime);
		transform.position = position;
	}

	private void CheckBounds()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
		if (transform.position.y + GetComponent<Collider2D>().bounds.size.y / 2 < min.y)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PlayerShipTag"))
		{
			Explode();
		}
		if (collision.CompareTag("PlayerBulletTag"))
		{
			TakeDamage(1);
		}
	}

	private void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Explode();
		}
	}
	private void Explode()
	{
		audioSource.Play();

		GameObject explosion = Instantiate(AsteroidExpolosion);

		explosion.transform.position = transform.position;

		int currentLevel = GameManager.Instance.GetCurrentLevel();

		if (currentLevel == 2)
		{
			explosion.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
		}

		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		Destroy(gameObject, audioSource != null ? audioSource.clip.length : 0.5f);
	}
}