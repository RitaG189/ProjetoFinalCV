using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwitch : MonoBehaviour
{

    void Update()
    {
        var fireEmission = gameObject.GetComponent<ParticleSystem>().emission;
        if ((PlayerPrefs.GetInt("Time") == 3 || PlayerPrefs.GetInt("Time") == 4) && PlayerPrefs.GetInt("isRaining") == 0)
        {
            fireEmission.enabled = true;
        }
        else
        {
            fireEmission.enabled = false;
        }
    }
}
