using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
	//public float speed = 10f;
	public Rigidbody2D rb;
	public CircleCollider2D dmgCollid;
	public SpriteRenderer spr;
	public GameObject playerGO;
	public Transform player;
	public GameObject explosionPrefab;
	
	/*
	public GameObject meteorGO;
	public Transform meteorTarget;
	*/

	private Vector2 meteorTarget;
	private float speed;
	private bool end = false;

	// Start is called before the first frame update
	void Start()
	{
		speed = 15f;
		rb = this.GetComponent<Rigidbody2D>();
		dmgCollid.enabled = false;
		spr.flipX = false;
		
		if (transform.position.x > 0) {
			spr.flipX = true;
		}

		playerGO = GameObject.Find("Player");
		player = playerGO.transform;

		/*
		meteorGO = GameObject.Find("MeteorTarget");
		meteorTarget = meteorGO.transform;
		*/

		float randomX = Random.Range(-2.4f, 2.4f);
		float randomY = Random.Range(-2.4f, 2.4f);
		meteorTarget = new Vector2(player.transform.position.x + randomX, player.transform.position.y + randomY);
	
	}

    private void FixedUpdate()
    {
		if (end == false) 
		{
			if (transform.position.x == meteorTarget.x && transform.position.y == meteorTarget.y)
			{
				end = true;
				//StartCoroutine(Destroy());
				Explode();
			}
			else
			{
				transform.position = Vector2.MoveTowards(transform.position, meteorTarget, speed * Time.deltaTime);
			}
		}
	}

	/*
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("detectou colisao, transform" + transform);
		var enemy = other.collider.GetComponent<Enemy1>();
		if (enemy != null)
		{			
			enemy.TakeDamage(damage);
			enemy.Knockback(transform);
			Debug.Log("transform" + transform);
			//StartCoroutine(JustKnockbacked());
		}
	}
	*/
	/*
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

	IEnumerator Destroy()
	{		
		dmgCollid.enabled = true;
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
	}
	*/

	private void Explode()
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
