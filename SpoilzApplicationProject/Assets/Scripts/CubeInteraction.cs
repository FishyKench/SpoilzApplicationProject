using System;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door;
    public void Interact()
    {
        door.SetActive(false);
    }
}
