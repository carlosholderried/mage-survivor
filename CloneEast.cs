using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneEast : MonoBehaviour
{
    public Transform player;
    public GameObject playerGO;
    public GameObject explosionPrefab;
    public SpriteRenderer spr;

    private bool end = false;
    private Vector2 east;
    private float speed;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
        player = playerGO.transform;

        speed = 3;

        east = new Vector2(player.transform.position.x+2f, player.transform.position.y);

        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!end)
        {
            if (Math.Abs(transform.position.x - east.x) < 0.05 && Math.Abs(transform.position.y - east.y) < 0.05)
            {
                end = true;
                Destroy();
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, east, speed * Time.deltaTime);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy1 enemy = hitInfo.GetComponent<Enemy1>();
        if (enemy != null)
        {
            Destroy();
        }

        Enemy2 enemy2 = hitInfo.GetComponent<Enemy2>();
        if (enemy2 != null)
        {
            Destroy();
        }

        Enemy3 enemy3 = hitInfo.GetComponent<Enemy3>();
        if (enemy3 != null)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        if (first)
        {
            first = false;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}