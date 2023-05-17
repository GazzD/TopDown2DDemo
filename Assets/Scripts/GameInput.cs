using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions inputActions;

    public bool isGamepad;

    private void Awake()
    {

        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();


        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public Vector2 GetMovementVector(bool normalized = false)
    {
        Vector2 movementVector = inputActions.Player.Move.ReadValue<Vector2>();

        //movementVector = movementVector.normalized;
        //print(movementVector);

        return normalized ? movementVector.normalized : movementVector;
    }

    public Vector2 GetAimVector(bool normalized = false)
    {
        Vector2 aimVector = inputActions.Player.Aim.ReadValue<Vector2>();

        //aimVector = aimVector.normalized;

        return normalized ? aimVector.normalized : aimVector;
    }

    public bool GetJumpInputDown()
    {
        return inputActions.Player.Jump.triggered;
    }

    public bool GetFireInputDown()
    {
        return inputActions.Player.Fire.triggered;
    }
    public bool GetPauseInputDown()
    {
        return inputActions.Player.Pause.triggered;
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme != null && pi.currentControlScheme.Equals("Gamepad");
    }


}
