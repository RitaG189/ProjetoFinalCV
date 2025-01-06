using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public GameObject[] artGalleryObjects;
    public GameObject[] paintingObjects;  

    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        UpdateObjectStates(currentScene);
    }

    public void SwitchScene(string targetSceneName)
    {

        if (currentScene == "Museu")
        {
            SetActiveObjects(artGalleryObjects, false);
        }
        else if (currentScene == "Painting")
        {
            SetActiveObjects(paintingObjects, false);
        }

        
        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
        currentScene = targetSceneName;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateObjectStates(scene.name);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void UpdateObjectStates(string sceneName)
    {
        if (sceneName == "Museu")
        {
            SetActiveObjects(artGalleryObjects, true);
            SetActiveObjects(paintingObjects, false);
        }
        else if (sceneName == "Painting")
        {
            SetActiveObjects(artGalleryObjects, false);
            SetActiveObjects(paintingObjects, true);
        }
    }

    private void SetActiveObjects(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}
