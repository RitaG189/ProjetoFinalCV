using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    void Update()
    {
        if(PlayerPrefs.GetInt("Time") == 3 || PlayerPrefs.GetInt("Time") == 4)
        {
            gameObject.GetComponent<Light>().enabled = true;
        }
        else 
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
