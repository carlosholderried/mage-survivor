using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPoint : MonoBehaviour
{
    public GameObject player;

    public GameObject throwP;

    public float speed;

    public float rotationModifier;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}