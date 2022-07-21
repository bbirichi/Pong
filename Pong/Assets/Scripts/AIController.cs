using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // ball reference
    private Transform ball;
    [SerializeField] private float moveSpeed = 0.01f;

    private void FixedUpdate()
    {
        FollowBall();
    }

    void FollowBall()
    {
        if (GameObject.FindGameObjectWithTag("Ball") != null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball").transform;

            if (ball.transform.position.y > transform.position.y)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }

            if (ball.transform.position.y < transform.position.y)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }

            BindPaddleToScreen();
        }
    }

    void BindPaddleToScreen()
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
