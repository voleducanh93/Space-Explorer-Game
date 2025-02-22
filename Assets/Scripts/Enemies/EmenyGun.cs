using UnityEngine;

public class Emeny1Gun : MonoBehaviour
{
	public GameObject enemyBulletGO;
	void Start()
	{
		Invoke("FireEnemyBullet", 1f);
	}

	void Update()
	{

	}

	public void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find("PlayerGO");

		if(playerShip != null )
		{
			GameObject bullet = (GameObject)Instantiate(enemyBulletGO);

			bullet.transform.position = transform.position;

			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			bullet.GetComponent<EmemyBullet>().SetDirection(direction);
		}
	}
}
