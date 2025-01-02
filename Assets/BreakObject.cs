using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class BreakObject : MonoBehaviour
{

    [SerializeField] GameObject intactObject;
    [SerializeField] GameObject brokenObject;

    BoxCollider bc;

    private void Awake()
    {
        intactObject.SetActive(true);
        brokenObject.SetActive(false);

        bc = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão foi com o objeto "Chão"
        if (collision.gameObject.CompareTag("Chao"))
        {
            Debug.Log("Colidiu com o chão");
            Break();
        }
    }

    // Update is called once per frame
    private void Break()
    {
        intactObject.SetActive(false);
        brokenObject.SetActive(true);

        bc.enabled = false;
    }
}
