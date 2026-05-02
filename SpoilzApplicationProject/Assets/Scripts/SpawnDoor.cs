using UnityEngine;

public class SpawnDoor : MonoBehaviour
{

    public GameObject door;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetActive(true);
        }
    }
}
