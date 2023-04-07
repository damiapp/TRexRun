using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOBeans : MonoBehaviour
{
    public JetPack jetPack;
    
    private void OnTriggerEnter2D(Collider2D collsion) {
        if(collsion.CompareTag("Player")){
            jetPack.Refuel();
        }
    }

    
}
