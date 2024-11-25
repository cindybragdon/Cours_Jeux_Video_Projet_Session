using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public Text PickUpText;
    public Text Item;
    public Text fadeAwayText;


    public float throwForce = 500f;
    public float pickUpRange = 7f;
    private float rotationSensitivity = 1f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private bool canDrop = true;
    private int LayerNumber;

    private Inventory inventory;

    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        PickUpText.gameObject.SetActive(false);
        Item.gameObject.SetActive(false);
        fadeAwayText.gameObject.SetActive(false);
    
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            
            if (hit.transform.gameObject.CompareTag("Pickable") )
            {
                if (heldObj == null)
                {
                    PickUpText.text = "PRESS [E] TO PICK UP";
                }
                else
                {
                    PickUpText.text = "PRESS [E] TO STORE IN INVENTORY";
                }
                
                Item.text = hit.transform.name;
                PickUpText.gameObject.SetActive(true);
                Item.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject targetObj = hit.transform.gameObject;
                    
                    if (heldObj == null)
                    {
                        PickUpObject(targetObj);
                        fadeAwayText.text = targetObj.name;
                        inventory.AddItem(heldObj);
                        fadeAwayText.gameObject.SetActive(true);
                    
                    }
                    else
                    {
                        AddToInventoryOnly(targetObj);
                    }
                    inventory.DisplayInventory();
                }
            }
        }
        else
        {
            PickUpText.gameObject.SetActive(false);
            Item.gameObject.SetActive(false);
        }

        if (heldObj != null)
        {
            MoveObject();

            if (Input.GetKeyDown(KeyCode.F) && canDrop)
            {
                StoreHeldObjectInInventory();
            }
            
            if (Input.GetKeyDown(KeyCode.Q) && canDrop)
            {
                DropObject();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop)
            {
                StopClipping();
                ThrowObject();
            }
        }
        if(heldObj == null){
            fadeAwayText.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            StoreHeldObjectInInventory();
            string objName = ShowObject(0);
            fadeAwayText.text = objName;
            fadeAwayText.gameObject.SetActive(true);
        } 
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            StoreHeldObjectInInventory();
            string objName = ShowObject(1);
            fadeAwayText.text = objName;
            fadeAwayText.gameObject.SetActive(true);
        } 
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            StoreHeldObjectInInventory();
            string objName = ShowObject(2);
            fadeAwayText.text = objName;
            fadeAwayText.gameObject.SetActive(true);
        } 
         if(Input.GetKeyDown(KeyCode.Alpha4)){
            StoreHeldObjectInInventory();
            string objName = ShowObject(3);
            fadeAwayText.text = objName;
            fadeAwayText.gameObject.SetActive(true);
        } 
    }

    void AddToInventoryOnly(GameObject obj)
    {
        if (obj != null)
        {
            inventory.AddItem(obj);
            obj.SetActive(false);
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObj.transform.parent = holdPos;
            heldObj.transform.position = holdPos.transform.position;
            heldObj.transform.rotation = holdPos.transform.rotation;
            heldObj.layer = LayerNumber;
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void StoreHeldObjectInInventory()
    {
        if (heldObj != null)
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObj.SetActive(false);
            heldObj.transform.parent = null;
            heldObj = null;
            heldObjRb = null;
        }
    }

    void DropObject()
    {
        if (heldObj != null)
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            inventory.RemoveItem(heldObj);
            heldObj = null;
            heldObjRb = null;
        }
    }

    string ShowObject(int item)
    {
        GameObject pickUpObj = inventory.getItem(item);
        PickUpObject(pickUpObj);
        pickUpObj.SetActive(true);
        return pickUpObj.gameObject.name;
    }

    void MoveObject()
    {
        if (heldObj != null)
        {
            heldObj.transform.position = holdPos.position;
        }
    }

    void ThrowObject()
    {
        if (heldObj != null)
        {
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            heldObjRb.AddForce(transform.forward * throwForce);
            inventory.RemoveItem(heldObj);
            heldObj = null;
            heldObjRb = null;
        }
    }

    void StopClipping()
    {
        if (heldObj != null)
        {
            var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

            if (hits.Length > 1)
            {
                heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            }
        }
    }
    
    


}
