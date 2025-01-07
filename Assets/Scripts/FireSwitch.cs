using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwitch : MonoBehaviour
{
    [SerializeField] private GameObject firePS;
    [SerializeField] private bool isBonfire;

    void Update()
    {

        if ((PlayerPrefs.GetInt("Time") == 3 || PlayerPrefs.GetInt("Time") == 4 || isBonfire) && PlayerPrefs.GetInt("isRaining") == 0)
        {
            firePS.SetActive(true);
        }
        else
        {
            firePS.SetActive(false);
        }
    }
}
