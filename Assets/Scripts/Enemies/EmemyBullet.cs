using UnityEngine;

public class EmemyBullet : MonoBehaviour
{
	float speed;
	Vector2 _direction;
	bool isReady;

	private void Awake()
	{
		speed = 5f;
		isReady = true;
	}
	void Start()
	{

	}

	public void SetDirection(Vector2 direction)
	{
		_direction = direction.normalized;

		isReady = true;
	}
	void Update()
	{
		if (isReady)
		{
			Vector2 position = transform.position;

			position += _direction * speed * Time.deltaTime;

			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

			if ((transform.position.x < min.x) || (transform.position.x > max.y) || (transform.position.y < min.y) || (transform.position.y > max.y))
				Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "PlayerShipTag")
		{
			Destroy(gameObject);
		}
	}
}
