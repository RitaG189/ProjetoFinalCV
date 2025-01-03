using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform grabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.freezeRotation = true; // Impede que o objeto rode automaticamente
    }

    public void Drop()
    {
        this.grabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.freezeRotation = false; // Permite que o objeto volte a rodar livremente
    }

    private void FixedUpdate()
    {
        if (grabPointTransform != null)
        {
            // Movimentação para o ponto de agarrar
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);

            // Rotação controlada pelo teclado
            float rotationSpeed = 100f;
            float rotationX = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            objectRigidbody.MoveRotation(objectRigidbody.rotation * Quaternion.Euler(rotationX, rotationY, 0));
        }
    }
}

