// Ce script permet à un joueur de ramasser et déposer des objets dans un jeu en utilisant un rayon de détection. 
// Lorsqu'un objet "Pickable" est dans le champ de vision, son nom est affiché, et une invite pour le ramasser ("Press E to pickup") apparaît.
// L'objet peut être ramassé avec la touche "E" et équipé à un parent d'arme, ou déposé avec la touche "Q".

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastControll : MonoBehaviour
{
    public float seenRange = 4.0f;
    public Text ObjectName;
    public Text Todo;
    private GameObject ObjectPickup;
    public Transform WeaponParent;

    void Start(){
        ObjectName.gameObject.SetActive(false);
        Todo.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        // Perform raycast to detect objects in range
        if (Physics.Raycast(transform.position, transform.forward, out hit, seenRange))
        {
            ObjectName.text = hit.transform.name;
            Todo.text = "Press E to pickup";
            ObjectPickup = hit.transform.gameObject;
            
            Debug.Log("You are seeing " + hit.transform.name + ".");

            if (hit.transform.CompareTag("Pickable")) {
                ObjectName.gameObject.SetActive(true);
                Todo.gameObject.SetActive(true);

                // Equip item when E is pressed
                if (Input.GetKeyDown(KeyCode.E)) { 
                    Equip();
                }

                // Drop item when Q is pressed
                if (Input.GetKeyDown(KeyCode.Q)) {
                    Drop();
                }
            } else {
                ObjectName.gameObject.SetActive(false);
                Todo.gameObject.SetActive(false);
            }
        }

        // Debug ray for visualization
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * seenRange, Color.magenta);
    }

    void Drop()
    {
        if (ObjectPickup != null)
        {
            WeaponParent.DetachChildren(); // Detach from the weapon parent
            ObjectPickup.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
            ObjectPickup.GetComponent<MeshCollider>().enabled = true; // Enable collision

            // Optionally reset the rotation when dropped
            ObjectPickup.transform.rotation = Quaternion.identity; // Set to default rotation (or you can define another value)
        }
    }

    void Equip()
    {
        if (ObjectPickup != null && WeaponParent != null)
        {
            ObjectPickup.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
            ObjectPickup.GetComponent<MeshCollider>().enabled = false; // Disable collision

            // Position the object at the weapon parent and align rotation
            ObjectPickup.transform.position = WeaponParent.position;
            ObjectPickup.transform.rotation = WeaponParent.rotation;

            // Parent the object to the weapon parent
            ObjectPickup.transform.SetParent(WeaponParent);
        }
    }
}
