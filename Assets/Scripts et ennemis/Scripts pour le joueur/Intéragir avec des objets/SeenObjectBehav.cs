// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class TestObject : MonoBehaviour, iGazeReceiver 
// {

//     //https://www.immersivelimit.com/detect-when-looking-at-object
//     private bool isGazingUpon;

//     public float floatingSpeed;
//     public GameObject PickUpUi;
//     public Text ObjectName; 

//     public AudioSource audioSourceOfEntity;

//     public AudioClip audioClipGun;

//     public AudioClip audioCliSomethingDied;


//     public void GazingUpon()
//     {
//         isGazingUpon = true;
//         PickUpUi.SetActive(true);
//         ObjectName.text = gameObject.name;
//         ObjectName.gameObject.SetActive(true);
    
        
        
//     }

//     public void NotGazingUpon()
//     {
//         isGazingUpon = false;
//         PickUpUi.SetActive(false);
//         ObjectName.gameObject.SetActive(false);
        
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//          PickUpUi.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (isGazingUpon)
//         {
//             if(Input.GetKeyDown(KeyCode.E)) {
//                 Destroy(gameObject);
//                 PickUpUi.SetActive(false);
//                 ObjectName.gameObject.SetActive(false);
//                 audioSourceOfEntity.PlayOneShot(audioCliSomethingDied);
                
//             }
            
//         }
//     }
// }
