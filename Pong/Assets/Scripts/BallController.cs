using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BallController : MonoBehaviour
{
    GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            GameManager = GameObject.FindGameObjectWithTag("GameManager");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftGoal"))
        {
            GameManager.GetComponent<GameManager>().RightScored();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("RightGoal"))
        {
            GameManager.GetComponent<GameManager>().LeftScored();
            Destroy(gameObject);
        }
    }
}
