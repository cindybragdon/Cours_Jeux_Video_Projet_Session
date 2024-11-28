using System.Numerics;
using NUnit.Framework.Constraints;
using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class DoorOpeningScript : MonoBehaviour
{
    public GameObject player; 
    
    public Animator MainDoorAnimation;
    public Animator SafeDoorAnimation;

    public Text text;
    public Text toDO;
    GameObject triggerOpening;

    PickUpScript pickUpScript;
    private UnityEngine.Vector3 oPosition;
    
    int interactRange = 3;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float elapsedTime = 0;

    private float timeToWait = 2;

    private bool isLevelChanging = false;
    void Start()
    {
       pickUpScript= player.GetComponent<PickUpScript>();
       triggerOpening = GameObject.FindWithTag("FacePadLock");
       triggerOpening.gameObject.SetActive(false);
       text.gameObject.SetActive(false);   
       toDO.gameObject.SetActive(false);
       oPosition =   triggerOpening.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(isLevelChanging) {

            elapsedTime += Time.deltaTime;
            if(elapsedTime >= timeToWait) {
                SceneManager.LoadScene("Level2");
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out hit, interactRange)){
            if(hit.transform.gameObject.CompareTag("MainDoor")){
                text.text = "PRESS [E] TO OPEN THE DOOR";
                text.gameObject.SetActive(true);
                
                if (Input.GetKeyDown(KeyCode.E)) {
                    if (pickUpScript.heldObj != null && pickUpScript.heldObj.name == "Key") {
                        MainDoorAnimation.SetBool("Close", false);
                        MainDoorAnimation.SetBool("Open", true);
                        isLevelChanging = true;


                    } else {
                        toDO.text = "GO FIND THE KEY";
                    }
            }
            } 
            
           

            if(hit.transform.gameObject.CompareTag("PadLock")){
                if(Input.GetKeyDown(KeyCode.E)){
                    triggerOpening.SetActive(true);
                } 
            }
            
        } else {
            text.gameObject.SetActive(false);
        }
    }
}
