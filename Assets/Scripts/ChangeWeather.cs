using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    [Header("Weather Effects")]

    [SerializeField] private ParticleSystem rainParticleSystem;
    [SerializeField] private ParticleSystem fogParticleSystem;


    [Header("Button Pressed")]
    public int weatherButtonPressed;

    private bool isRaining;
    private bool isFog;

    private void Awake() {
        PlayerPrefs.SetInt("isRaining", 0);
    }

    private void Start() {
        weatherButtonPressed = 0;
        isRaining = false;
        isFog = false;

        var rainEmission = rainParticleSystem.emission;
        rainEmission.enabled = false;

        var fogEmission = fogParticleSystem.emission;
        fogEmission.enabled = false;
    }

    private void Update() 
    {
        var rainEmission = rainParticleSystem.emission;
        var fogEmission = fogParticleSystem.emission;


        if (weatherButtonPressed == 1) 
        {
            if(!isRaining)
            {
                // starts raining
                rainEmission.enabled = true;
                PlayerPrefs.SetInt("isRaining", 1);
                isRaining = true;
            }
            else if(isRaining)
            {
                //stops raining
                rainEmission.enabled = false;
                PlayerPrefs.SetInt("isRaining", 0);
                isRaining = false;
            }
        }
        else if(weatherButtonPressed == 2)
        {
            if (!isFog)
            {
                // starts fog
                fogEmission.enabled = true;
                isFog = true;
            }
            else if (isFog)
            {
                //stops fog
                fogEmission.enabled = false;
                isFog = false;
            }

        }

        weatherButtonPressed = 0;
    }
}
