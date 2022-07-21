using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    public void ProcessMovement(Vector2 input)
    {
        Vector3 movement = Vector3.zero;
        movement.y = input.y;

        transform.Translate(movement * moveSpeed * Time.deltaTime);

        BindPlayerToScreen();
    }

    private void BindPlayerToScreen()
    {
        // Top Side Binding
        if (transform.position.y > 13.00f)
        {
            transform.position = new Vector3(transform.position.x, 13.00f, transform.position.z);
        }

        // Bottom Side Binding
        if (transform.position.y < -13.00f)
        {
            transform.position = new Vector3(transform.position.x, -13.00f, transform.position.z);
        }
    }
}
