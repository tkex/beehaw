using System;
using UnityEngine;
using System.Collections.Generic;    // Don't forget to add this if using a List.
using UnityEngine.XR.Interaction.Toolkit;

public class Flower : MonoBehaviour
{

    // the controllers
    private XRBaseInteractor interactor;
    // get the XRGrabInteractable from current Game Object
    private XRGrabInteractable grabInteractable => GetComponent<XRGrabInteractable>();
    // [SerializeField] private XRGrabInteractable grabInteractable;

    private MeshRenderer meshRenderer = null;
    [SerializeField] private Material greyMaterial;
    [SerializeField] private Material pinkMaterial;

    // todo: what to cache?
    // todo: Component game pattern
    // todo: prototype game pattern (spawning rand. flowers once bees pass through)
    private void Awake()
    {
        var childObject = GetChildWithName(gameObject, "Petals");
        meshRenderer = childObject.GetComponent<MeshRenderer>();

        grabInteractable.selectEntered.AddListener(GrabbedBy);
        grabInteractable.selectExited.AddListener(GrabEnd);

    }
    private void onDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(GrabbedBy);
        grabInteractable.selectExited.RemoveListener(GrabEnd);
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform parentObjTransform = obj.transform;
        Transform childTransform = parentObjTransform.Find(name);
        if (childTransform != null)
        {
            return childTransform.gameObject;
        }
        else
        {
            return null;
        }
    }

    // todo: optional: dig out flower with trowel + hand only
    // Declare and initialize a new List of GameObjects called currentCollisions.
     List <GameObject> currentCollisions = new List <GameObject> ();
     public GameObject DirtScript;
     
     void OnCollisionEnter (Collision col) {
 
         // Add the GameObject collided with to the list.
         currentCollisions.Add (col.gameObject);
 
         // Print the entire list to the console.
         foreach (GameObject gObject in currentCollisions) {
             print (gObject.name);
         }
     }
 
     void OnCollisionExit (Collision col) {
 
         // Remove the GameObject collided with from the list.
         currentCollisions.Remove(col.gameObject);
 
         // Print the entire list to the console.
         foreach (GameObject gObject in currentCollisions) {
             print (gObject.name + " is out");

             if(gObject.name == "Trowel") {
                gameObject.SetActive(false);
                DirtScript.GetComponent<InstantiateDirt>().Spawn();
             }
         }

        
        // Instantiate Erde

     }

//      If (gameobject == bewässert= {
// -> Blume SetActive (True)
//      }

    private void onEnable()
    {
        // todo: find out why this doesn't trigger
    }

    private void onDisable()
    {
        // grabInteractable.selectEntered.RemoveListener(GrabbedBy);
        // grabInteractable.selectExited.RemoveListener(GrabEnd);
    }

    private void onUpdate()
    {
        var controllerRotationAngle = GetControllerRotation();
        var controllerPosition = GetControllerPosition();

        // GetRotationDistance(controllerRotationAngle);
    }

    void Update()
    {

    }


    public float GetControllerRotation() => interactor.GetComponent<Transform>().eulerAngles.z;
    public Vector3 GetControllerPosition() => interactor.GetComponent<Transform>().position;
    // TODO
    // if threshold difference between original y-position and upward movement is crossed
    // activate tracking on flower
    // else 
    // nothing happens / a little shaky / stretching

    private void GetRotationDistance(float controllerRotationAngle)
    {
        throw new NotImplementedException();
    }

    private void GrabbedBy(SelectEnterEventArgs arg0)
    {
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
        if(interactor.name == "RightHand Controller") {
            arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(0.5f, 10f);

            print("STATE " + arg0.interactor.GetComponent<XRBaseController>().GetControllerState(out XRControllerState controllerState));
        }
        
        meshRenderer.material = pinkMaterial;

        print(interactor + "or " + arg0.interactor);
    }

    private void GrabEnd(SelectExitEventArgs arg0)
    {
        meshRenderer.material = greyMaterial;
    }

    private void dirtIsLeft(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);
        // grabInteractable.trackPosition = true;
        // grabInteractable.trackRotation = true;
    }

}
