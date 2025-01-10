using UnityEngine;

public class LightActivator : MonoBehaviour
{
    private Light lightSource;
    private Camera mainCamera;
    private Renderer objectRenderer;

    void Start()
    {
        // Obter a luz e a c�mera principal
        lightSource = GetComponent<Light>();
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>(); // Para objetos com Renderers
    }

    void Update()
    {
        if (IsVisibleFrom(mainCamera))
        {
            print("isVisible");
            if (!lightSource.enabled) // Ativa apenas se ainda n�o estiver ativa
                lightSource.enabled = true;
        }
        else
        {
            print("isNotVisible");
            if (lightSource.enabled) // Desativa apenas se estiver ativa
                lightSource.enabled = false;
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
