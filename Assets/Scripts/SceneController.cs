using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject museumLights;

    void Start()
    {
        player.transform.position = teleportDestination.position;
        PlayerPrefs.SetString("CurrentScene", "Museum");

    }


}
