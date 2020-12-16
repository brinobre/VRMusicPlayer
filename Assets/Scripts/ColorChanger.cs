using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material PlayMaterial = null;
    public Material PauseMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable hoverInteractor = null;

    public bool isPlaying;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hoverInteractor = GetComponent<XRBaseInteractable>();

        PlayMaterial = meshRenderer.material;

            hoverInteractor.onHoverEntered.AddListener(ChangeMaterial);
    }
    
    private void OnDestroy()
    {
            hoverInteractor.onHoverEntered.RemoveListener(ChangeMaterial);
    }
    
    private void ChangeMaterial(XRBaseInteractor interactor)
    {
        if (!isPlaying)
        {
            meshRenderer.material = PlayMaterial;
            isPlaying = true;

        } else
        {
            meshRenderer.material = PauseMaterial;
            isPlaying = false;
            FindObjectOfType<AudioManager>().Play("Ukulele");

        }


    }
}
