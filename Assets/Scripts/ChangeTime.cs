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
    [SerializeField] private Light directionaLight;

    [Header("Light Settings")]
    private Color morningLightColor = Color.white; 
    private float morningLightIntensity = 0.56f;   
    private Color dayLightColor = Color.white; 
    private float dayLightIntensity = 1.2f;   
    private Color sunsetLightColor = new Color(0.8018868f, 0.3066828f, 0.1626469f);   
    private float sunsetLightIntensity = 0.4f;     
    private Color nightLightColor = new Color(0.2264151f, 0.2264151f, 0.2264151f);  
    private float nightLightIntensity = 0.58f;       

    [Header("Button Pressed")]
    public int timeButtonPressed;

    private void Start() {
        timeButtonPressed = 2;
    }

    private void Update() 
    {
        switch(timeButtonPressed)
        {
            case 1: 
                PlayerPrefs.SetInt("Time", 1);
                ChangeToTime(morningSkybox, morningOvercastSkybox, morningLightIntensity, morningLightColor );
                break;
            case 2: 
                PlayerPrefs.SetInt("Time", 2);
                ChangeToTime(daySkybox, dayOvercastSkybox, dayLightIntensity, dayLightColor);
                break;
            case 3: 
                PlayerPrefs.SetInt("Time", 3);
                ChangeToTime(sunsetSkybox, sunsetOvercastSkybox, sunsetLightIntensity, sunsetLightColor);
                break;
            case 4:
                PlayerPrefs.SetInt("Time", 4);
                ChangeToTime(nightSkybox, nightOvercastSkybox, nightLightIntensity, nightLightColor);
                break;
            default:
                PlayerPrefs.SetInt("Time", 2);
                ChangeToTime(daySkybox, dayOvercastSkybox, dayLightIntensity, dayLightColor);
                break;
        }
        DynamicGI.UpdateEnvironment();
    }

    private void ChangeToTime(Material skybox, Material overcastSkybox, float lightIntensity, Color lightColor)
    {
        if(PlayerPrefs.GetInt("isRaining") == 1)
        {
            RenderSettings.skybox = overcastSkybox;
            UpdateLightSettings(lightColor, lightIntensity);
        }
        else
        {
            RenderSettings.skybox = skybox;
            UpdateLightSettings(lightColor, lightIntensity);
        }

    }

    private void UpdateLightSettings(Color lightColor, float lightIntensity)
    {
        if (directionaLight != null)
        {
            directionaLight.color = lightColor;
            directionaLight.intensity = lightIntensity;
        }
    }
}
