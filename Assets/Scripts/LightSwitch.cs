using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private bool isLamp;
    void Update()
    {

        if(PlayerPrefs.GetInt("Time") == 3 || PlayerPrefs.GetInt("Time") == 4)
        {
            if(PlayerPrefs.GetInt("isRaining") == 0 || isLamp)
                gameObject.GetComponent<Light>().enabled = true;
            else
                gameObject.GetComponent<Light>().enabled = false;
        }
        else 
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
