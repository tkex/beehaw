using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReticleBehaviour : MonoBehaviour
{
    public TeleportationAnchor teleportationAnchor;

    // Start is called before the first frame update
    void Start()
    {
        // different way of doing it, closer to docs & with type correction
        //teleportationAnchor = (TeleportationAnchor)GetComponent<BaseTeleportationInteractable>();

        teleportationAnchor = GetComponent<TeleportationAnchor>();

    }

    // Update is called once per frame
    void Update()
    {
        // rotate only when visible
        teleportationAnchor.customReticle.GetComponent<Transform>().Rotate(0f, 2f, 0f);
        Debug.Log("tele " + teleportationAnchor.customReticle.GetComponent<Transform>().rotation);
    }
}
