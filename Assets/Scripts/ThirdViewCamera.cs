// Ce script gère la caméra à la troisième personne, permettant de suivre un "target" (cible) avec une rotation de la caméra contrôlée par la souris, ainsi qu'un ajustement dynamique de la distance de la caméra pour éviter les collisions et les obstructions. 
// Il offre également une option pour verrouiller le curseur et ajuster la sensibilité de la souris. 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdViewCamera : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Transform target;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float smoothing = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    Vector3 cameraDirection;
    float camDistance;
    Vector2 cameraDistanceMinMax = new Vector2(1f, 3f);
    public Transform cam;

    void Start()
    {   
        cameraDirection = cam.transform.localPosition.normalized;
        camDistance = cameraDistanceMinMax.y;

        if(lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, smoothing);
        transform.eulerAngles = currentRotation;

        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5f);

        CheckCameraOcclusionAndCollision(cam);
    }

    public void CheckCameraOcclusionAndCollision(Transform cam) {
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
        RaycastHit hit;
        if(Physics.Linecast(transform.position, desiredCameraPosition, out hit)) {
            camDistance = Mathf.Clamp(hit.distance, cameraDistanceMinMax.y, cameraDistanceMinMax.y);
        } else {
            camDistance = cameraDistanceMinMax.y;
        }
        cam.localPosition = cameraDirection * camDistance;
    }
}
