using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform BallPrefab;

    private int leftScore, rightScore = 0;

    [SerializeField] private float ballSpeed = 20f;

    [SerializeField] private TMP_Text rightScoreText;
    [SerializeField] private TMP_Text leftScoreText;

    private void Start()
    {
        rightScoreText.text = rightScore.ToString();
        leftScoreText.text = leftScore.ToString();

        SpawnBallLeft();
    }

    public void RightScored()
    {
        rightScore++;
        Debug.Log("Right Scored: " + rightScore);
        rightScoreText.text = rightScore.ToString();
        SpawnBallLeft();
    }

    public void LeftScored()
    {        
        leftScore++;
        Debug.Log("Left Scored: " + leftScore);
        leftScoreText.text = leftScore.ToString();
        SpawnBallRight();
    }

    // Spawn ball left
    private void SpawnBallLeft()
    {
        Transform  ball = Instantiate(BallPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.0f,RandomizeAngle(), 0.0f) * ballSpeed;
    }

    // Spawn ball right
    private void SpawnBallRight()
    {
        Transform ball = Instantiate(BallPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector3(1.0f, RandomizeAngle(), 0.0f) * ballSpeed;
    }

    private float RandomizeAngle()
    {
        return Random.Range(-0.5f, 0.5f);
    }
}
