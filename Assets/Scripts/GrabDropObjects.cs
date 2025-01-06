using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabDropObjects : MonoBehaviour
{
    [SerializeField] Transform playerCamTransform;
    [SerializeField] Transform grabPointTransform;
    [SerializeField] LayerMask pickUpLayerMask;
    private Grabbable objectGrabbable;

    [SerializeField] TMP_Text textRotate;
    [SerializeField] TMP_Text textGrab;
    [SerializeField] TMP_Text textDrop;
    [SerializeField] TMP_Text textExplode;

    private void Start()
    {
        textRotate.enabled = false;
        textGrab.enabled = false;
        textDrop.enabled = false;
        textExplode.enabled = false;
    }

    private void Update()
    {
        //Detectar objetos agarráveis com Raycast
        float pickUpDistance = 2f;
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
        {
            //Verificar se o objeto é agarrável
            if (raycastHit.transform.TryGetComponent<Grabbable>(out Grabbable detectedGrabbable))
            {
                if (raycastHit.transform.CompareTag("Explode"))
                {
                    textExplode.enabled = true;
                }
                if (objectGrabbable == null)
                {
                    textGrab.enabled = true;
                }
            }
        }
        else
        {
            if (objectGrabbable == null)
            {
                textGrab.enabled = false;
                textExplode.enabled = false;
            }
        }

        //Agarrar ou largar objetos
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(grabPointTransform);
                        textRotate.enabled = true;
                        textDrop.enabled = true;
                        textGrab.enabled = false;
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
                textRotate.enabled = false;
                textDrop.enabled = false;
                textGrab.enabled = false;
            }
        }
    }
}
