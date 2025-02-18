using UnityEngine;

public class StarController : MonoBehaviour
{
	private const int score = 10;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	private void Update()
	{
		MoveStar();
		CheckBounds();
	}

	private void MoveStar()
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
			audioSource.Play();

			ScoreManager.Instance.AddScore(score);

			Destroy(gameObject, audioSource.clip.length);
		}
	}
}
