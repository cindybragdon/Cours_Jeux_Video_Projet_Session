using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IARobot : MonoBehaviour
{
        // Variable sérialisée exposée dans l'inspecteur pour ajuster la vitesse du robot dans Unity
    [SerializeField] float speed = 1f;
 
    // Déclaration d'un rayon qui sera utilisé pour détecter les obstacles devant le robot
    Ray rayon;
 
    // Déclaration d'une variable pour stocker les informations de collision lorsque le rayon touche un objet
    RaycastHit hit;
 
    // Variables sérialisées pour assigner les capteurs gauche et droit du robot dans l'éditeur Unity
    [SerializeField] Transform leftSensor, rightSensor;

    private Animator animator; 
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
         animator.enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
       rayon = new Ray(leftSensor.position, transform.TransformDirection(Vector3.forward));

       if(Physics.Raycast(rayon, out hit, Mathf.Infinity))
       {
        Debug.Log("Left Sensor Onject:" + hit.collider.name + " Distance " + hit.distance);

        if(hit.distance <1 )
        {
            float angle = Random.Range(100f, 300f);
            transform.Rotate(Vector3.up * angle * ( Time.deltaTime/4));
        } 
       } 

       Debug.DrawRay(leftSensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);

       rayon = new Ray(rightSensor.position, transform.TransformDirection(Vector3.forward));

       if (Physics.Raycast(rayon, out hit, Mathf.Infinity))
       {
        Debug.Log("Right sensor object:" + hit.collider.name + "Distance" + hit.distance);
       }
       if ( hit.distance < 1 ) 
       {
        float angle = Random.Range(100f, 300f);
        transform.Rotate(Vector3.up * angle * ( Time.deltaTime/4));
       }

        Debug.DrawRay(rightSensor.position, transform.TransformDirection(Vector3.forward) * 10f, Color.yellow);

        transform.Translate(Vector3.forward * speed * ( Time.deltaTime/4));
    }

}


