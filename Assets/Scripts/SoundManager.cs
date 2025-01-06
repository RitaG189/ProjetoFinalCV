using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource paintingAS;

    void Update()
    {
        if(PlayerPrefs.GetString("CurrentScene") == "Painting")
            paintingAS.enabled = true;
        else
            paintingAS.enabled = false;
    }
}
