using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        rb.velocity = -Vector3.forward * speed;
    }
}
