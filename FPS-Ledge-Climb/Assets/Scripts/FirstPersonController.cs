using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    //properties used to help check whether player can use certain mechanics. These are mostly to keep the code clean and organized
    //Kind of a rudimentary/crude state machine
    public bool PlayerCanMove { get; private set; } = true;
    private bool PlayerIsSprinting => playerCanSprint && Input.GetKey(sprintKey) && !playerIsCrouching;
    private bool PlayerShouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded && !playerIsCrouching;
    private bool PlayerShouldCrouch => Input.GetKeyDown(crouchKey) && !playerInCrouchAnimation && characterController.isGrounded;

    //Checks used to see if player is able to use mechanics.
    [Header("Functional Options")]
    [Tooltip("Is the player in the middle of a special movement, i.e. ladder climbing?")]
    [SerializeField]
    public bool playerOnSpecialMovement = false;
    [SerializeField]
    private bool playerCanSprint = true;
    [SerializeField]
    private bool playerCanJump = true;
    [SerializeField]
    private bool playerCanCrouch = true;
    [SerializeField]
    private bool playerCanHeadbob = true;

    //The keys that players must press to use mechanics/actions
    [Header("Controls")]
    [SerializeField]
    private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode crouchKey = KeyCode.LeftControl;

    //parameters for different movement speeds
    [Header("Movement Parameters")]
    [SerializeField]
    private float walkSpeed = 3f;
    [SerializeField]
    private float sprintSpeed = 6f;
    [SerializeField]
    private float crouchSpeed = 1.5f;
    [SerializeField]
    private float fovDefault = 60f;
    [SerializeField]
    private float fovSprint = 70f;
    [SerializeField]
    private float fovIncrement = 5f;

    //Parameters for looking around with mouse
    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)]
    private float lookSpeedX = 2f;
    [SerializeField, Range(1, 10)]
    private float lookSpeedY = 2f;
    [SerializeField, Range(1, 100)]
    private float upperLookLimit = 80f;
    [SerializeField, Range(1, 100)]
    private float lowerLookLimit = 80f;

    //Parameters for jump height and gravity
    [Header("Jumping Parameters")]
    [SerializeField]
    private float jumpForce = 8f;
    [SerializeField]
    private float gravity = 30f;

    //Parameters for crouching. The height and center will directly affect the CharacterController height and center.
    [Header("Crouch Parameters")]
    [SerializeField]
    private float crouchingHeight = 0.5f;
    [SerializeField]
    private float standingHeight = 2f;
    [SerializeField]
    private float timeToCrouch = 0.25f; //How long should the crouching animation take?
    [SerializeField]
    private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    [SerializeField]
    private Vector3 standingCenter = new Vector3(0, 0, 0); //Didn't use Vector3.Zero so that it would be customizable in inspector
    private bool playerIsCrouching; //Is the player currently crouched?
    private bool playerInCrouchAnimation; //Is the player currently in the middle of the crouching animation?

    [Header("Headbob Parameters")]
    [SerializeField]
    private float walkBobSpeed = 14f;
    [SerializeField]
    private float walkBobAmount = 0.05f;
    [SerializeField]
    private float sprintBobSpeed = 18f;
    [SerializeField]
    private float sprintBobAmount = 0.1f;
    [SerializeField]
    private float crouchBobSpeed = 8f;
    [SerializeField]
    private float crouchBobAmount = 0.025f;
    private float defaultYPosCamera = 0;
    private float timer; 

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput; //Whether player is moving vertically or horizontally along x and z planes

    private float rotationX = 0f; //Camera rotation for clamping
    
    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        defaultYPosCamera = playerCamera.transform.localPosition.y;

        //Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera.fieldOfView = fovDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerOnSpecialMovement)
        {
            if (PlayerCanMove)
            {
                HandleMovementInput();
                HandleMouseLook();

                if (playerCanJump)
                {
                    HandleJump();
                }

                if (playerCanCrouch)
                {
                    HandleCrouch();
                }

                if (playerCanHeadbob)
                {
                    HandleHeadbob();
                }

                //Apply all the movement parameters that are found earlier in the frame (above in Update())
                ApplyFinalMovements();
            }
        }
        else if (playerOnSpecialMovement)
        {
            HandleMouseLook();
        }

    }

    private void HandleMovementInput()
    {
        if (PlayerIsSprinting && playerCamera.fieldOfView < fovSprint)
        {
            playerCamera.fieldOfView += fovIncrement * Time.deltaTime;
        }
        else if (!PlayerIsSprinting && playerCamera.fieldOfView > fovDefault)
        {
            playerCamera.fieldOfView -= fovIncrement * Time.deltaTime;
        }
        //else
        //{
        //    playerCamera.fieldOfView = fovDefault;
        //}

        //when the player presses W and S or A and D
        //Check to see what speed they are going, based on whether they are crouching, sprinting, or simply walking
        currentInput = new Vector2((playerIsCrouching ? crouchSpeed : PlayerIsSprinting ?  sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), 
            (playerIsCrouching ? crouchSpeed : PlayerIsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        //The direction in which the player moves based on input
        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;

    }

    private void HandleMouseLook()
    {
        //rotate camera around X and Y axis, and rotate player around x axis
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit); //clamp camera
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void HandleJump()
    {
        //only jump if property conditions are met
        if (PlayerShouldJump)
        {
            moveDirection.y = jumpForce;
        }
    }

    private void HandleCrouch()
    {
        //only crouch if property conditions are met
        if (PlayerShouldCrouch)
        {
            StartCoroutine(CrouchStand());
        }
    }

    private void HandleHeadbob()
    {
        if (!characterController.isGrounded)
        {
            return;
        }

        if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (playerIsCrouching ? crouchBobSpeed : PlayerIsSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPosCamera + Mathf.Sin(timer) * (playerIsCrouching ? crouchBobAmount : PlayerIsSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }

    private void ApplyFinalMovements()
    {
        //make sure the player is on the ground if applying gravity (after pressing Jump)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //move the player based on the parameters gathered in the "Handle-" functions
        characterController.Move(moveDirection * Time.deltaTime);
    }

    //Coroutine that handles crouching/standing
    private IEnumerator CrouchStand()
    {
        //make sure there is nothing above player's head that should prevent them from standing, if there is, do not allow them to stand
        if (playerIsCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
        {
            yield break;
        }

        //player is now in crouching animation
        playerInCrouchAnimation = true;

        float timeElapsed = 0; //amount of time elapsed during animation
        float targetHeight = playerIsCrouching ? standingHeight : crouchingHeight; //target height based on the state the player is in when they press crouch button
        float currentHeight = characterController.height; //the player's height when they press the crouch button
        Vector3 targetCenter = playerIsCrouching ? standingCenter : crouchingCenter; //target center based on the state the player is in when they press crouch button
        Vector3 currentCenter = characterController.center; //the player's center when they press the crouch button

        //while the animation is still going
        while(timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch); //change the current height to the target height
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch); //change the current center to the target center

            timeElapsed += Time.deltaTime; //increment the time elapsed based on the time it took between frames

            yield return null;
        }

        //Sanity check :P
        characterController.height = targetHeight;
        characterController.center = targetCenter;

        playerIsCrouching = !playerIsCrouching; //update whether or not the player is crouching

        playerInCrouchAnimation = false; //the crouching animation has ended
    }
}
