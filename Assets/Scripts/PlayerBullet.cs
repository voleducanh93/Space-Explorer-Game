using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public int scorePerHit = 1;

	float speed;

	void Start()
	{
		speed = 5f;
	}

	void Update()
	{
		Vector2 position = transform.position;

		position = new Vector2(position.x, position.y + speed * Time.deltaTime);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		if (transform.position.y > max.y)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("AsteroidSpawnerTag"))
		{
			Destroy(gameObject);
		}
	}
}
