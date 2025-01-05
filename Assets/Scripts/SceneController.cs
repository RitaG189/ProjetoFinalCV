using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform teleportDestination; 

    void Start()
    {
        player.transform.position = teleportDestination.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
