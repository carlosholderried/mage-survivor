using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	//public float speed = 10f;
	public Rigidbody2D rb;
	public Transform player;
	public GameObject playerGO;

	private Vector3 newRotation;
	private float z;
	private int damage = 100;
	// Start is called before the first frame update
	void Start()
	{
		playerGO = GameObject.Find("Player");
		player = playerGO.transform;

		z = 0;
		damage = 100;
		rb = this.GetComponent<Rigidbody2D>();
		//rb.velocity = transform.right * speed;
		GetComponent<Collider2D>().enabled = true;

		z = 0;
	}

    private void FixedUpdate()
    {
		if (z < 361) 
		{
			transform.position = player.position;
			newRotation = new Vector3(0, 0, z);
			transform.eulerAngles = newRotation;
			z=z+12;
		}
        else 
		{
			Destroy(gameObject);
		}
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
}
