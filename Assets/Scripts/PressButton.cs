using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressButton : MonoBehaviour
{
    [SerializeField] int buttonNumber;
    [SerializeField] bool isTimeButton;

    [SerializeField] GameObject timeUI;
    [SerializeField] GameObject rainUI;
    [SerializeField] GameObject fogUI;
    [SerializeField] GameObject thunderUI;

    private bool canPressButton;

    private void Start() {
        canPressButton = false;
    }

    private void Update() {
        if (canPressButton && isTimeButton)
        {
            if (Input.GetMouseButtonDown(0))
                GameObject.FindGameObjectWithTag("TimeManager").GetComponent<ChangeTime>().timeButtonPressed++;
        }

        if (canPressButton && !isTimeButton)
        {
            if (Input.GetMouseButtonDown(0))
                GameObject.FindGameObjectWithTag("WeatherManager").GetComponent<ChangeWeather>().weatherButtonPressed = buttonNumber;
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            canPressButton = true;

        if (this.CompareTag("ButtonTime"))
            timeUI.SetActive(true);

        if (this.CompareTag("ButtonRain"))
            rainUI.SetActive(true);

        if (this.CompareTag("ButtonFog"))
            fogUI.SetActive(true);

        if (this.CompareTag("ButtonThunder"))
            thunderUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
            canPressButton = false;

        if (this.CompareTag("ButtonTime"))
            timeUI.SetActive(false);

        if (this.CompareTag("ButtonRain"))
            rainUI.SetActive(false);

        if (this.CompareTag("ButtonFog"))
            fogUI.SetActive(false);

        if (this.CompareTag("ButtonThunder"))
            thunderUI.SetActive(false);
    }
}
