// Ce script permet de contrôler la caméra à la première personne en fonction du mouvement de la souris. 
// Il ajuste l'angle de la caméra en hauteur et la rotation du joueur horizontalement.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraBehavior : MonoBehaviour
{
    public Transform player;
    public float mouseSensibility = 2f;
    public float cameraVerticalRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X")*mouseSensibility;
        float inputY = Input.GetAxis("Mouse Y")*mouseSensibility;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
