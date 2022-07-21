using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{

    public Slider HungerSlider;
    public static float Hunger;
    public static float maxHunger = 1000f;

    void Start()
    {
        HungerSlider.minValue = 0;
        HungerSlider.maxValue = maxHunger;
        Hunger = maxHunger;
    }


    void Update()
    {
        HungerSlider.value = Hunger;
        // Debug.Log(Hunger);

        if (Hunger > 0)
        {    
            Hunger -= 1 * Time.deltaTime;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                Hunger -= 3 * Time.deltaTime;   
            }
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))){
                Hunger -= 5 * Time.deltaTime;   
            }
        }
        else{
            //TODO DEATH
            // Debug.Log("You starved to death");
        }

    }

}
