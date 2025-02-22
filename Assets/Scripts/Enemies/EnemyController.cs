using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyGO;
	public GameObject ememyEngineGO;
	private Animator animator;
	private AudioSource audioSource;

	float speed;
	public int score;
	public float health;
	public int damage;

	protected virtual void Start()
	{
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		speed = 2f;
	}

	protected virtual void Update()
	{
		Vector2 position = transform.position;

		position = new Vector2(position.x, position.y - speed * Time.deltaTime);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		CheckBounds();

	}

	private void CheckBounds()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
		if (transform.position.y + GetComponent<Collider2D>().bounds.size.y / 2 < min.y)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "PlayerShipTag" || collision.tag == "PlayerBulletTag")
		{
			TakeDamage(1);
		}
	}

	void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			audioSource.Play();
			ScoreManager.Instance.AddScore(score);
			ememyEngineGO.gameObject.SetActive(false);

			GetComponent<Collider2D>().enabled = false;
			animator.SetBool("isDestroyed", true);
		}
	}
}
