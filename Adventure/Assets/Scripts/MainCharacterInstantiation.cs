using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterInstantiation : MonoBehaviour
{
    public GameObject MainCharacter;
    public GameObject MCPositionAtStart;

    void Start()
    {
        Instantiate(MainCharacter, MCPositionAtStart.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
