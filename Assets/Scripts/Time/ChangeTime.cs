using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    [Header("Skyboxes")]
    [SerializeField] private Material morningSkybox;
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material sunsetSkybox;
    [SerializeField] private Material nightSkybox;

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
                ChangeToMorning();
                break;
            case 2: 
                ChangeToDay();
                break;
            case 3: 
                ChangeToSunset();
                break;
            case 4:
                ChangeToNight();
                break;
            default:
                ChangeToDay();
                break;
        }
        DynamicGI.UpdateEnvironment();
    }

    public void ChangeToMorning()
    {
        RenderSettings.skybox = morningSkybox;
        UpdateLightSettings(morningLightColor, morningLightIntensity);
    }

    public void ChangeToDay()
    {
        RenderSettings.skybox = daySkybox;
        UpdateLightSettings(dayLightColor, dayLightIntensity);
    }

    public void ChangeToSunset()
    {
        RenderSettings.skybox = sunsetSkybox;
        UpdateLightSettings(sunsetLightColor, sunsetLightIntensity);
    }

    public void ChangeToNight()
    {
        RenderSettings.skybox = nightSkybox;
        UpdateLightSettings(nightLightColor, nightLightIntensity);
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
