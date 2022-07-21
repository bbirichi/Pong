using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform BallPrefab;

    private int leftScore, rightScore = 0;

    [SerializeField] private float ballSpeed = 20f;

    [SerializeField] private TMP_Text rightScoreText;
    [SerializeField] private TMP_Text leftScoreText;

    [SerializeField] private TMP_Text winText;
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject winOverlay;

    bool isPaused = false;

    private void Start()
    {
        rightScoreText.text = rightScore.ToString();
        leftScoreText.text = leftScore.ToString();

        UnpauseGame();
        pauseOverlay.SetActive(isPaused);

        SpawnBallLeft();
    }

    public void ProcessPausing()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }       
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseOverlay.SetActive(isPaused);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseOverlay.SetActive(isPaused);
    }

    public void ExitToStartMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void RightScored()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        if (rightScore >= 10)
        {
            winText.text = "You Lose";
            winOverlay.SetActive(true);
        }
        else
        {
            SpawnBallLeft();
        }        
    }

    public void LeftScored()
    {        
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        if (leftScore >= 10)
        {
            winText.text = "You Win!";
            winOverlay.SetActive(true);
        }
        else
        {
            SpawnBallRight();
        }        
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
