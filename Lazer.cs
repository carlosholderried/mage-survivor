using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
	private float speed = 10f;
	public Rigidbody2D rb;
	private int damage = 6;

	// Start is called before the first frame update
	void Start()
	{
		rb.velocity = transform.right * speed;
		StartCoroutine(DestroyLazer());
	}

	// Update is called once per frame a
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			player.PlayerTakeDamage(damage);
			Destroy(gameObject);
		}
	}

	IEnumerator DestroyLazer()
	{
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
	}
}