using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthSlider;

    public static float Health;

    public static float maxHealth = 100f;

    void Start()
    {
        HealthSlider.minValue = 0;
        HealthSlider.maxValue = maxHealth;
        Health = maxHealth;
    }

    void Update()
    {
        HealthSlider.value = Health;
        // Debug.Log(Health);

        if(Input.GetKeyUp(KeyCode.K) && Health >= 10){
            Health -= 10;
        }


        if(Health <= 0){
            //TODO DEATH
            Debug.Log("You are dead");
        }

    }
}
