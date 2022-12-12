using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.PlayerTakeDamage(damage);
            player.Knockback(transform);
        }
    }
}
