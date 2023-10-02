using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

   

    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            DataStorage.instance.IncreaseScore(1);
            Destroy(this.gameObject);
        }
    }
    
}
