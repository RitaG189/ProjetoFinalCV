using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDropObjects : MonoBehaviour
{

    [SerializeField] Transform playerCamTransform;
    [SerializeField] Transform grabPointTransform;
    [SerializeField] LayerMask pickUpLayerMask;
    private Grabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabbable == null)
            {
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(grabPointTransform);
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
