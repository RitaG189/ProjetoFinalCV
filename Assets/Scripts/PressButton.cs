using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressButton : MonoBehaviour
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private bool isTimeButton;

    private bool canPressButton;

    private void Start() {
        canPressButton = false;
    }

    private void Update() {
        if (canPressButton && Input.GetMouseButtonDown(0) && isTimeButton)
        {
            GameObject.FindGameObjectWithTag("TimeManager").GetComponent<ChangeTime>().timeButtonPressed++;
        }
        else if(canPressButton && Input.GetMouseButtonDown(0) && !isTimeButton)
        {
            GameObject.FindGameObjectWithTag("WeatherManager").GetComponent<ChangeWeather>().weatherButtonPressed = buttonNumber;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            canPressButton = true;
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
            canPressButton = false;
    }
}
