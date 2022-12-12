using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public Transform player;
	public GameObject playerGO;

	private int damage = 100;

    private void Start()
    {
		playerGO = GameObject.Find("Player");
		player = playerGO.transform;
		player.GetComponent<Player>().playExplosionSFX();
	}

    void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
		if (enemy != null)
		{			
			enemy.TakeDamage(damage);
			enemy.Knockback(transform);
		}

		Enemy2 enemy2 = hitInfo.GetComponent<Enemy2>();
		if (enemy2 != null)
		{
			enemy2.TakeDamage(damage);
			enemy2.Knockback(transform);
		}

		Enemy3 enemy3 = hitInfo.GetComponent<Enemy3>();
		if (enemy3 != null)
		{
			enemy3.TakeDamage(damage);
			enemy3.Knockback(transform);
		}
	}

	public void Destroy()
    {
		Destroy(gameObject);
    }
}