using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerInput : MonoBehaviour
{
    PlayerController controller;
    PlayerInputActions inputActions;
    PlayerInputActions.PlayerActions playerActions;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        inputActions = new PlayerInputActions();
        playerActions = inputActions.Player;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        controller.ProcessMovement(playerActions.Movement.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
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
