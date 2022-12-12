using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPixels : MonoBehaviour
{
	public Transform player;
	public GameObject playerGO;

	private void Start()
	{
		playerGO = GameObject.Find("Player");
		player = playerGO.transform;
	}

    private void FixedUpdate()
    {
		transform.position = player.position;
    }

    public void Destroy()
	{
		Destroy(gameObject);
	}
}