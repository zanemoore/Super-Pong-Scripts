using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Written by Zane/Darius
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject leftPlayerWinScreen;
    [SerializeField] private GameObject rightPlayerWinScreen;
    [SerializeField] private GameObject Ball;
    [SerializeField] private Text leftScoreText;
    [SerializeField] private Text rightScoreText;
    [SerializeField] private float matchPoint;

    private bool gameOver = false;

    public int leftPlayerScore;
    public int rightPlayerScore;

    private void Start()
    {
        Time.timeScale = 0;
        leftPlayerScore = 0;
        rightPlayerScore = 0;
    }

    private void Update()
    {
        if (leftPlayerScore == matchPoint && gameOver == false)
        {
            LeftPlayerWins();
            gameOver = true;
        }
        else if (rightPlayerScore == matchPoint && gameOver == false)
        {
            RightPlayerWins();
            gameOver = true;
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateLeftPlayerScore()
    {
        // adds a point to the left player's score 
        leftPlayerScore++;

        // increases match point by one if the score is tied at 10
        if (leftPlayerScore >= 10 && leftPlayerScore == rightPlayerScore)
        {
            matchPoint++;
        }

        // converts the score from string to text on the screen
        if (leftPlayerScore < 10)
        {
            leftScoreText.text = "0" + leftPlayerScore.ToString();
        }
        else
        {
            leftScoreText.text = leftPlayerScore.ToString();
        }

        // resets ball when a player scores
        Ball.GetComponent<BallMovement>().BallReset();
    }

    public void UpdateRightPlayerScore()
    {
        // adds a point to the right player's score 
        rightPlayerScore++;

        // increases match point by one if the score is tied at 10
        if (rightPlayerScore >= 10 && leftPlayerScore == rightPlayerScore)
        {
            matchPoint++;
        }

        // converts the score from string to text on the screen 
        if (rightPlayerScore < 10)
        {
            rightScoreText.text = "0" + rightPlayerScore.ToString();
        }
        else
        {
            rightScoreText.text = rightPlayerScore.ToString();
        }

        // resets ball when a player scores
        Ball.GetComponent<BallMovement>().BallReset();
    }

    private void LeftPlayerWins()
    {
        // displays left player win screen
        leftPlayerWinScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void RightPlayerWins()
    {
        // displays right player win screen
        rightPlayerWinScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
