using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{

    [Header("Skyboxes")]
    [SerializeField] private Material morningSkybox;
    [SerializeField] private Material morningOvercastSkybox;

    [SerializeField] private Material daySkybox;
    [SerializeField] private Material dayOvercastSkybox;

    [SerializeField] private Material sunsetSkybox;
    [SerializeField] private Material sunsetOvercastSkybox;

    [SerializeField] private Material nightSkybox;
    [SerializeField] private Material nightOvercastSkybox;


    [Header("Light")]
    [SerializeField] private GameObject directionalLight;




    [Header("Button Pressed")]
    public int timeButtonPressed;

    private void Start() {
        timeButtonPressed = 1;
    }

    private void Update() 
    {
        switch(timeButtonPressed)
        {
            case 1: 
                PlayerPrefs.SetInt("Time", 1);
                ChangeToTime(morningSkybox, morningOvercastSkybox, 0.22f, Color.white, 0.22f, Color.white);
                DynamicGI.UpdateEnvironment();
                break;
            case 2: 
                PlayerPrefs.SetInt("Time", 2);
                ChangeToTime(daySkybox, dayOvercastSkybox, 1.2f, Color.white, 0f, Color.white);
                DynamicGI.UpdateEnvironment();
                break;
            case 3: 
                PlayerPrefs.SetInt("Time", 3);
                ChangeToTime(sunsetSkybox, sunsetOvercastSkybox, 0.22f, new Color(0.8196079f, 0.4666667f, 0.1803922f), 0f, Color.white);
                DynamicGI.UpdateEnvironment();
                break;
            case 4:
                PlayerPrefs.SetInt("Time", 4);
                ChangeToTime(nightSkybox, nightOvercastSkybox, 0.22f, Color.white, 0f, Color.white);
                DynamicGI.UpdateEnvironment();
                break;
            default:
                timeButtonPressed = 1;
                PlayerPrefs.SetInt("Time", 1);
                ChangeToTime(daySkybox, dayOvercastSkybox, 0.4f, new Color(0.8018868f, 0.3066828f, 0.1626469f), 0f, Color.white);
                DynamicGI.UpdateEnvironment();
                break;
        }
    }

    private void ChangeToTime(Material skybox, Material overcastSkybox, 
                                float lightIntensity, Color lightColor, 
                                float overcastLightIntensity, Color overcastLightColor)
    {
        if(PlayerPrefs.GetInt("isRaining") == 1 || PlayerPrefs.GetInt("isFog") == 1)
        {
            RenderSettings.skybox = overcastSkybox;
            UpdateLightSettings(overcastLightColor, overcastLightIntensity);
            
        }
        else
        {
            RenderSettings.skybox = skybox;
            UpdateLightSettings(lightColor, lightIntensity);
        }

    }

    private void UpdateLightSettings(Color lightColor, float lightIntensity)
    {
        if (directionalLight != null)
        {
            directionalLight.GetComponent<Light>().color = lightColor;
            directionalLight.GetComponent<Light>().intensity  = lightIntensity;
        }
    }
}
