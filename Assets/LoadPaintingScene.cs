using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPaintingScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync("Painting", LoadSceneMode.Additive);
    }
}
