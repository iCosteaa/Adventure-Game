using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public float FoodValue = 50;
    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            if(HungerBar.Hunger + FoodValue < HungerBar.maxHunger){
                HungerBar.Hunger += FoodValue;
                Destroy(gameObject);
            }
        }
    }

}
