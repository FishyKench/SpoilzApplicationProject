using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float sensitivity = 0.2f;
    [SerializeField] private float clampAngle = 85f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0.6f, 0f);

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        xRotation -= player.LookInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        player.transform.Rotate(Vector3.up * player.LookInput.x * sensitivity);

        Vector3 rotatedOffset = player.transform.rotation * offset;
        transform.position = player.transform.position + rotatedOffset;
        transform.rotation = Quaternion.Euler(xRotation, player.transform.eulerAngles.y, 0f);
    }
}