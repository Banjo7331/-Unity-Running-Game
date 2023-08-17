using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        rb.velocity = -Vector3.forward * speed;
    }
    //private void Update()
    //{
      //  rb.velocity = Vector3.up * 5;
    //}
}
