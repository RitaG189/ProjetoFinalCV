using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform grabPointTransform;
    private float currentDistance = 0.8f;
    private float minDistance = 0.5f;
    private float maxDistance = 1.0f;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.freezeRotation = true;
    }

    public void Drop()
    {
        this.grabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (grabPointTransform != null)
        {
            //Aproximar ou afastar o objeto
            if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.N))
            {
                currentDistance = Mathf.Max(minDistance, currentDistance - 0.01f); //Aproximar
            }
            if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.M))
            {
                currentDistance = Mathf.Min(maxDistance, currentDistance + 0.01f); //Afastar
            }

            grabPointTransform.localPosition = new Vector3(0, 0, currentDistance);

            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);

            //Rotação
            float rotationSpeed = 100f;
            float rotationX = 0f;
            float rotationY = 0f;
            float rotationZ = 0f;

            if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.U)) rotationX = rotationSpeed * Time.deltaTime; //Cima
            if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.J)) rotationX = -rotationSpeed * Time.deltaTime;  //Baixo
            if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.H)) rotationY = rotationSpeed * Time.deltaTime; //Esquerda
            if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.K)) rotationY = -rotationSpeed * Time.deltaTime;  //Direita
            if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Y)) rotationZ = rotationSpeed * Time.deltaTime; //Inclina Esquerda
            if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey(KeyCode.I)) rotationZ = -rotationSpeed * Time.deltaTime;  //Inclina Direita

            Quaternion rotationIncrement = Quaternion.Euler(rotationX, rotationY, rotationZ);

            objectRigidbody.MoveRotation(rotationIncrement * objectRigidbody.rotation);
        }
    }
}












