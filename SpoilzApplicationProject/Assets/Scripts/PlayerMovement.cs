using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float gravity = -20f;

    private CharacterController controller;
    private Vector2 inputValue;
    private float verticalVelocity;
    private bool jumpPressed;

    public Vector2 LookInput { get; private set; }

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

    public void OnJump(InputValue value)
    {
        jumpPressed = true;
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;

        Vector3 moveDirection = transform.forward * inputValue.y + transform.right * inputValue.x;

        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            if (jumpPressed)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity = verticalVelocity + gravity * Time.deltaTime;
        }

        jumpPressed = false;

        Vector3 move = moveDirection.normalized * moveSpeed;
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }
}