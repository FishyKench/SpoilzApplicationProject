using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private Transform cameraTransform;

    private IInteractable currentTarget;

    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        Debug.DrawRay(cameraTransform.position, cameraTransform.forward* interactionRange ,Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            currentTarget = hit.collider.GetComponent<IInteractable>();
        }
        else
        {
            currentTarget = null;
        }
    }

    public void OnInteract()
    {
        if(currentTarget != null)
        {
            currentTarget.Interact();
        }
    }

    public IInteractable GetCurrentTarget()
    {
        return currentTarget;
    }
}
