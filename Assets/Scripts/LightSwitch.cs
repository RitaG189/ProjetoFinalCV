using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private bool isLamp;
    private Renderer objectRenderer;
    private Camera mainCamera;
    private Light lightSource;



    private void Start() {
        lightSource = GetComponent<Light>();
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {

        if(PlayerPrefs.GetInt("Time") == 3 || PlayerPrefs.GetInt("Time") == 4)
        {
            if(PlayerPrefs.GetInt("isRaining") == 0 || isLamp)
                gameObject.GetComponent<Light>().enabled = true;
            else
                gameObject.GetComponent<Light>().enabled = false;
        }
        else 
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }

        private bool IsVisibleFrom(Camera cam)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (objectRenderer != null)
        {
            // Se o objeto tem Renderer, verifica contra o bounds
            return GeometryUtility.TestPlanesAABB(planes, objectRenderer.bounds);
        }
        else
        {
            // Caso n�o tenha um Renderer (por exemplo, apenas luzes), usa a posi��o
            return GeometryUtility.TestPlanesAABB(planes, new Bounds(transform.position, Vector3.one));
        }
    }
}
