using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource natureAS;
    [SerializeField] private AudioSource nightAS;


    void Update()
    {
        if(PlayerPrefs.GetString("CurrentScene") == "Painting")
        {
            if (PlayerPrefs.GetInt("Time") == 1 || PlayerPrefs.GetInt("Time") == 2)
            {
                natureAS.enabled = true;
                nightAS.enabled = false;
            }
            else
            {
                natureAS.enabled = false;
                nightAS.enabled = true;
            }
        }
        else
        {
            natureAS.enabled = false;
            nightAS.enabled = false;
        }
    }
}
