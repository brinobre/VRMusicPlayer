using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{

    public Material greyMaterial = null;
    public Material blueMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable hoverInteractor = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hoverInteractor = GetComponent<XRBaseInteractable>();

        hoverInteractor.onHoverEntered.AddListener(SetBlue);
        hoverInteractor.onHoverExited.AddListener(SetGrey);
    }

    private void OnDestroy()
    {
        hoverInteractor.onHoverEntered.RemoveListener(SetBlue);
        hoverInteractor.onHoverExited.RemoveListener(SetGrey);
    }

    private void SetGrey(XRBaseInteractor interactor)
    {
        meshRenderer.material = greyMaterial;
    }

    private void SetBlue(XRBaseInteractor interactor)
    {
        meshRenderer.material = blueMaterial;
    }
}
