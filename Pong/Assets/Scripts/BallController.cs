using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BallController : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 20f;

    GameObject GameManager;
    AudioSource ballAudio;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballAudio = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            GameManager = GameObject.FindGameObjectWithTag("GameManager");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftGoal"))
        {
            GameManager.GetComponent<GameManager>().RightScored(transform.position);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("RightGoal"))
        {
            GameManager.GetComponent<GameManager>().LeftScored(transform.position);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballAudio.Play();

        if (collision.gameObject.CompareTag("LeftRacket"))
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y);
            rb.velocity = direction * ballSpeed;
        }

        if (collision.gameObject.CompareTag("RightRacket"))
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y);
            rb.velocity = direction * ballSpeed;
        }
    }

    // Get position ball hits racket
    private float HitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}
