using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        float turnY = Mathf.Sin(Time.time *4 ) *2;
        rb.velocity = -Vector3.forward * speed + Vector3.up * turnY; 
    }
}
