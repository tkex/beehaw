using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketEvents : MonoBehaviour
{

    #region Variables

    // Get XRSocketInteractor from current GameObject
    private XRSocketInteractor socket => GetComponent<XRSocketInteractor>();

    public bool hasEnteredSocket = false;

    #endregion


    #region Functions

    private void Awake()
    {
        // Add listeners for socket events.
        socket.selectEntered.AddListener(SocketFilled);
        socket.selectExited.AddListener(SocketRemoved);
    }

    private void OnDestroy()
    {
        // Remove listeners for socket events.
        socket.selectEntered.RemoveListener(SocketFilled);
        socket.selectExited.RemoveListener(SocketRemoved);
    }

    private void SocketFilled(SelectEnterEventArgs arg)
    {
        // Set hasEnteredSocket to true.
        hasEnteredSocket = true;

        //Debug.Log("Gameobject has been placed inside socket.");

        // Remove XR Grab Interactable so object can't be removed.
        // At the moment: There's no official way to disable the Grab Interaction in a simple manner.
        // With destroying or setting another Layer Mask the Socket-Snap will lose it's effect as well.
        // Destroy(arg.interactable.GetComponent<XRGrabInteractable>());

        // XRGrabInteractable grabInteractable = arg.interactable.GetComponent<XRGrabInteractable>();
        // grabInteractable.interactionLayerMask = 0;
    }

    // Function for settings attribute 
    private void SocketRemoved(SelectExitEventArgs arg)
    {
        // Set hasEnteredSocket to false.
        hasEnteredSocket = false;

        //Debug.Log("Gameobject has been removed.");
    }

    #endregion
}
