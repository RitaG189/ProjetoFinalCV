using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    [Header("Weather Effects")]

    [SerializeField] private ParticleSystem rainParticleSystem;

    [Header("Button Pressed")]
    public int weatherButtonPressed;

    private bool isRaining;

    private void Awake() {
        PlayerPrefs.SetInt("isRaining", 0);
    }

    private void Start() {
        weatherButtonPressed = 0;
        isRaining = false;

        var emission = rainParticleSystem.emission;
        emission.enabled = false;
    }

    private void Update() 
    {
        var emission = rainParticleSystem.emission;

        if(weatherButtonPressed == 1) 
        {
            if(!isRaining)
            {
                // starts raining
                emission.enabled = true;
                PlayerPrefs.SetInt("isRaining", 1);
                isRaining = true;
            }
            else if(isRaining)
            {
                //stops raining
                emission.enabled = false;
                PlayerPrefs.SetInt("isRaining", 0);
                isRaining = false;
            }
        }

        weatherButtonPressed = 0;
    }
}
