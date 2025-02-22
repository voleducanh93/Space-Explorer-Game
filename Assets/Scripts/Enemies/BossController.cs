using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BossController : MonoBehaviour
{
	public GameObject bossGO;
	public Transform firePoint;
	public GameObject bossBulletGO;
	public float moveSpeed = 2f;
	public float appearDuration = 5f;
	public float disappearDuration = 2f;
	public float health;
	public int score;
	public int damge;

	private Animator animator;
	private AudioSource audioSource;
	private Vector2 minScreenBounds;
	private Vector2 maxScreenBounds;
	private Vector2 spawnPosition;
	private Vector2 appearPosition;

	private void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();

		minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector2(0.1f, 0.6f));
		maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector2(0.9f, 0.9f));

		spawnPosition = new Vector2(0, maxScreenBounds.y + 5f);
		transform.position = spawnPosition;

		appearPosition = new Vector2(0, maxScreenBounds.y - 0.1f);

		StartCoroutine(BossRoutine());
	}

	private IEnumerator BossRoutine()
	{
		yield return MoveToPosition(appearPosition);
		yield return new WaitForSeconds(2f);

		for (int i = 0; i < 3; i++)
		{
			if (GameManager.Instance != null && GameManager.Instance.GMState == GameManager.GameManagerState.GameOver)
			{
				StartCoroutine(BossExit());
				yield break;
			}

			animator.SetBool("isShooting", true);
			yield return new WaitForSeconds(2.0f);
			audioSource.Play();
			SpawnBullet();
			yield return new WaitForSeconds(0.5f);
			animator.SetBool("isShooting", false);

			yield return new WaitForSeconds(3f);
		}

		animator.SetBool("isShooting", false);

		for (int i = 0; i < 2; i++)
		{
			if (GameManager.Instance != null && GameManager.Instance.GMState == GameManager.GameManagerState.GameOver)
			{
				StartCoroutine(BossExit());
				yield break;
			}

			Vector2 newPosition = GetRandomXPosition();
			yield return MoveToPosition(newPosition);

			animator.SetBool("isShooting", true);
			yield return new WaitForSeconds(2f);

			float shootDuration = 5f;
			float shootInterval = shootDuration / 10f;
			for (int j = 0; j < 10; j++)
			{
				audioSource.Play();
				SpawnBullet();

				yield return new WaitForSeconds(shootInterval);
			}

			animator.SetBool("isShooting", false);
			yield return new WaitForSeconds(5f);
		}

		StartCoroutine(BossExit());
	}

	private IEnumerator BossExit()
	{
		Vector2 exitPosition = new Vector2(transform.position.x, maxScreenBounds.y + 5f);
		yield return MoveToPosition(exitPosition);
		Destroy(gameObject);
	}

	private void SpawnBullet()
	{
		Instantiate(bossBulletGO, firePoint.position, Quaternion.identity);
	}

	private Vector2 GetRandomXPosition()
	{
		return new Vector2(Random.Range(minScreenBounds.x, maxScreenBounds.x), transform.position.y);
	}

	private IEnumerator MoveToPosition(Vector2 target)
	{
		while (Vector2.Distance(transform.position, target) > 0.1f)
		{
			transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
			yield return null;
		}
	}

}
