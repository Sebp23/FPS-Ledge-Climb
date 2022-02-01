using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public bool PlayerCanMove { get; private set; } = true;
    private bool PlayerIsSprinting => playerCanSprint && Input.GetKey(sprintKey);
    private bool PlayerShouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded;

    [Header("Functional Options")]
    [SerializeField]
    private bool playerCanSprint = true;
    [SerializeField]
    private bool playerCanJump = true;

    [Header("Controls")]
    [SerializeField]
    private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [Header("Movement Parameters")]
    [SerializeField]
    private float walkSpeed = 3f;
    [SerializeField]
    private float sprintSpeed = 6f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)]
    private float lookSpeedX = 2f;
    [SerializeField, Range(1, 10)]
    private float lookSpeedY = 2f;
    [SerializeField, Range(1, 100)]
    private float upperLookLimit = 80f;
    [SerializeField, Range(1, 100)]
    private float lowerLookLimit = 80f;

    [Header("Jumping Parameters")]
    [SerializeField]
    private float jumpForce = 8f;
    [SerializeField]
    private float gravity = 30f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0f;
    
    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        //Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCanMove)
        {
            HandleMovementInput();
            HandleMouseLook();

            if (playerCanJump)
            {
                HandleJump();
            }

            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        //when the player presses W and S or A and D
        currentInput = new Vector2((PlayerIsSprinting ?  sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), 
            (PlayerIsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;

    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit); //clamp camera
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void HandleJump()
    {
        if (PlayerShouldJump)
        {
            moveDirection.y = jumpForce;
        }
    }

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
