using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerInput : MonoBehaviour
{
    PlayerController controller;
    PlayerInputActions inputActions;
    PlayerInputActions.PlayerActions playerActions;
    
    GameManager gameManager;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        inputActions = new PlayerInputActions();
        playerActions = inputActions.Player;

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        playerActions.Pause.performed += context => gameManager.ProcessPausing();
    }

    private void FixedUpdate()
    {
        controller.ProcessMovement(playerActions.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
