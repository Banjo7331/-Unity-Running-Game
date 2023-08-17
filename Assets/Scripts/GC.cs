using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Danger" || other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
