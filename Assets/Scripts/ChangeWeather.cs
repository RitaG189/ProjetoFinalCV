using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    [Header("Weather Effects")]

    [SerializeField] private GameObject rainParticleSystem;
    [SerializeField] private GameObject fogParticleSystem;
    [SerializeField] private GameObject thunderSystem;


    [Header("Button Pressed")]
    public int weatherButtonPressed;

    private bool isRaining;
    private bool isFog;
    private bool isThunder;

    private void Awake() {
        PlayerPrefs.SetInt("isRaining", 0);
        PlayerPrefs.SetInt("isFog", 0);
        PlayerPrefs.SetInt("isThunder", 0);

    }

    private void Start() {
        weatherButtonPressed = 0;
        isRaining = false;
        isFog = false;
        isThunder = false;

        rainParticleSystem.SetActive(false);
        fogParticleSystem.SetActive(false);
        thunderSystem.SetActive(false);

    }

    private void Update() 
    {
        switch(weatherButtonPressed)
        {
            case 1:
                if (!isRaining)
                {
                    // starts raining
                    rainParticleSystem.SetActive(true);
                    //rainEmission.enabled = true;
                    PlayerPrefs.SetInt("isRaining", 1);
                    isRaining = true;
                }
                else if (isRaining)
                {
                    //stops raining
                    rainParticleSystem.SetActive(false);

                    //rainEmission.enabled = false;
                    PlayerPrefs.SetInt("isRaining", 0);
                    isRaining = false;
                }
                break;
            case 2:
                if (!isFog)
                {
                    // starts fog
                    //RenderSettings.fog = true;
                    fogParticleSystem.SetActive(true);
                    PlayerPrefs.SetInt("isFog", 1);
                    isFog = true;
                }
                else if (isFog)
                {
                    //stops fog
                    //RenderSettings.fog = false;
                    fogParticleSystem.SetActive(false);
                    PlayerPrefs.SetInt("isFog", 0);
                    isFog = false;
                }
                break;
            case 3:
                if(!isThunder)
                {
                    thunderSystem.SetActive(true);
                    PlayerPrefs.SetInt("isThunder", 1);
                    isThunder = true;
                }
                else if(isThunder)
                {
                    thunderSystem.SetActive(false);
                    PlayerPrefs.SetInt("isThunder", 0);
                    isThunder = false;
                }
                break;
        }

        weatherButtonPressed = 0;

    }
}
