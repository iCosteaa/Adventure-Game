using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public float HealthValue = 50;
    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            if(HealthBar.Health + HealthValue < HealthBar.maxHealth){
                HealthBar.Health += HealthValue;
                Destroy(gameObject);
            }
        }
    }
}
