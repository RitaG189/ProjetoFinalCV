using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeLight : MonoBehaviour
{
    [SerializeField] private GameObject morningLight;
    [SerializeField] private GameObject dayLight;
    [SerializeField] private GameObject sunsetLight;
    [SerializeField] private GameObject nightLight;

    private bool isOvercast;

    private void Update() 
    { 

        if(PlayerPrefs.GetInt("Time") == 1 && !isOvercast)
            morningLight.SetActive(true);
        else 
            morningLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 2 && !isOvercast)
            dayLight.SetActive(true);
        else 
            dayLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 3 && !isOvercast)
            sunsetLight.SetActive(true);
        else 
            sunsetLight.SetActive(false);

        if(PlayerPrefs.GetInt("Time") == 4 && !isOvercast)
            nightLight.SetActive(true);
        else 
            nightLight.SetActive(false);

        if ((PlayerPrefs.GetInt("isRaining") == 1 || PlayerPrefs.GetInt("isFog") == 1 || PlayerPrefs.GetInt("isThunder") == 1))
            isOvercast = true;
        else 
            isOvercast = false;
        
    }

}
