using System;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject gameTimerText;

    [SerializeField] private GameObject spawner;

    public void Interact()
    {
        door.SetActive(false);
        spawner.SetActive(true);
        gameTimerText.SetActive(true);
        FindFirstObjectByType<GameTimer>().StartTimer();
    }
}