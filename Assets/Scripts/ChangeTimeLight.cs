using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeLight : MonoBehaviour
{
    [SerializeField] private GameObject morningLight;
    [SerializeField] private GameObject dayLight;
    [SerializeField] private GameObject sunsetLight;
    [SerializeField] private GameObject nightLight;

    private void Update() 
    { 

        if(PlayerPrefs.GetInt("Time") == 1)
            morningLight.SetActive(true);
        else 
            morningLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 2)
            dayLight.SetActive(true);
        else 
            dayLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 3)
            sunsetLight.SetActive(true);
        else 
            sunsetLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 4)
            nightLight.SetActive(true);
        else 
            nightLight.SetActive(false);
    }

}
