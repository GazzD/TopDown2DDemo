using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.GridBrushBase;

//[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f; // The speed of the player
    //[SerializeField] private float jumpForce = 5f; // The jump force of the player
    [SerializeField] private float controllerDeadzone = 0.1f; // The deadzone of the controller
    [SerializeField] private float gamepadRotateSmoothing = 1000f; // The smoothing of the rotation when using a gamepad
    
    //private CharacterController controller;
    private bool isWalking;
    private Rigidbody2D rb;

    public Weapon weapon;
    private Vector2 mousePosition;
    private PlayerInput playerInput;
    //private PlayerInputActions playerInputActions; // PlayerControls 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        //playerInputActions = new PlayerInputActions();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.Instance.IsPaused)
        {
            return;
        }
        HandleMovement();
        HandleRotation();
        HandleInteraction();
    }

    private void HandleRotation()
    {
        if (GameInput.Instance.isGamepad)
        {
            // Rotate using sticks
            Vector2 aimInputVector = GameInput.Instance.GetAimVector(true);

            if (Mathf.Abs(aimInputVector.x) > controllerDeadzone || Mathf.Abs(aimInputVector.y) > controllerDeadzone)
            {
                Vector2 playerDirection = new Vector2(aimInputVector.x, aimInputVector.y);
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }

        }
        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimDirection = (mousePosition - (Vector2)transform.position).normalized;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;

            rb.rotation = aimAngle;

        }
    }

    private void HandleInteraction()
    {
        if (GameInput.Instance.GetFireInputDown())
        {
            weapon.Fire();
        }

    }

    private void HandleMovement()
    {
        Vector3 inputVector = GameInput.Instance.GetMovementVector();
        float moveDistance = movementSpeed * Time.deltaTime;
        // Move player
        transform.position += inputVector * moveDistance;
        //transform.Translate(inputVector * moveDistance);
        //rb.MovePosition(rb.position + inputVector * moveDistance);

        // Check if is walking to switch the animation
        isWalking = inputVector != Vector3.zero;
    }

}
