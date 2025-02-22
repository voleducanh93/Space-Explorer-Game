using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;

public class AsteroidController : MonoBehaviour
{
	public GameObject AsteroidExpolosion;
	public int health = 3;
	private AudioSource audioSource;
	

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();

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

		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		Destroy(gameObject, audioSource != null ? audioSource.clip.length : 0.5f);
	}
}