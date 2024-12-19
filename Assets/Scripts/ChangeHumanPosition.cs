using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHumanPosition : MonoBehaviour
{
    [SerializeField] private Vector3 normalPosition;
    [SerializeField] private Vector3 rainingPosition;

    private void Update() {
        if(PlayerPrefs.GetInt("isRaining") == 1)
            transform.position = rainingPosition;
        else
            transform.position = normalPosition;
        
    }

}
