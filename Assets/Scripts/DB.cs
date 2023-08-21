using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DB : MonoBehaviour
{
    public ModelBucketSpawner Spawner;
    
    
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "DropingModel")
        {
            Destroy(other.gameObject);
            Spawner.DeleteDroped();
        }
    }
}
