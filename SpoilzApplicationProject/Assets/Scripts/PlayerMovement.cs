using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    

    private CharacterController controller;
    private Vector2 inputValue;

    public Vector2 LookInput {get; private set;}

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        inputValue = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;
        Vector3 moveDirection = transform.forward * inputValue.y + transform.right * inputValue.x;
        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}