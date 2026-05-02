using System;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject gameTimerText;

    public void Interact()
    {
        door.SetActive(false);
        gameTimerText.SetActive(true);
        FindFirstObjectByType<GameTimer>().StartTimer();
    }
}