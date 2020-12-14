using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportController : MonoBehaviour
{
    public XRController rightTeleportRay;
    public XRController leftTeleportRay;
    public InputHelpers.Button teleportActivationButton;

    void Start()
    {
        // teleport ray is set to when the game starts
        rightTeleportRay.gameObject.SetActive(false);
        leftTeleportRay.gameObject.SetActive(false);
    }

    //This checks the input to see if it is pressed
    bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated);
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the right and left teleportray is activated
        rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay) && !leftTeleportRay.gameObject.activeInHierarchy);
        leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay) && !rightTeleportRay.gameObject.activeInHierarchy);
    }
}
