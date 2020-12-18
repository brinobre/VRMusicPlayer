using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableScroll : MonoBehaviour
{
    public XRBaseInteractable interactable;

    private Vector3 startPos;
    private Quaternion startRot;

    private void onEnable()
    {
        startPos = interactable.transform.position;
        startRot = interactable.transform.rotation;

        interactable.onHoverEntered.AddListener(OnHoverEnter);
    }

    private void OnDisable()
    {
        interactable.onHoverEntered.RemoveListener(OnHoverEnter);

    }
    void Update()
    {
        transform.LookAt(interactable.transform.position);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    private void OnHoverEnter(XRBaseInteractor arg0)
    {
        interactable.transform.position = startPos;
        interactable.transform.rotation = startRot;
    }
}
