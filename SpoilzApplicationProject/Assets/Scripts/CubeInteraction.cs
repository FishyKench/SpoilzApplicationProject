using System;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject target;
    public void Interact()
    {
        Debug.Log("has interacted with " + this.gameObject.name);
    }
}
