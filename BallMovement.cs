using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane/Darius
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;
    [SerializeField] private Rigidbody leftPaddleBody, rightPaddleBody;
    [SerializeField] private GameObject leftPaddle, rightPaddle;

    [SerializeField] public float ballSpeed;
    [SerializeField] private float paddleMultiplier;

    private float defaultSpeed;
    private float randomServeX;
    private float randomServeZ;


    void Start()
    {
        ball = GetComponent<Rigidbody>();
        defaultSpeed = ballSpeed;

        Invoke("BallServe", 2f);
    }

    private void BallServe()
    {
        // the ball is served in a random direction at a random angle
        if (Random.value < 0.5f)
        {
            randomServeZ = 1f;
        }
        else
        {
            randomServeZ = -1f;
        }

        if (Random.value > 0.5f)
        {
            randomServeX = Random.Range(0f, 1f);
        }
        else
        {
            randomServeX = Random.Range(-1f, 0f);
        }

        ball.velocity = new Vector3(randomServeX * ballSpeed * 1.25f, 0f, randomServeZ * ballSpeed * 1.25f);
        ball.transform.position = new Vector3(0f, 1f, 0f);
    }

    public void BallReset()
    {
        // the ball's position is reset after a player scores
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = new Vector3(0f, 1f, 0f);
        ballSpeed = defaultSpeed;

        Invoke("BallServe", 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float distanceLeft = ball.transform.position.x - leftPaddle.transform.position.x;

        if (collision.gameObject.name == "Left Player Paddle")
        {
            // sends the ball in the opposite direction depending on the velocity of the paddle
            if (leftPaddleBody.velocity.x > 0.1f)
            {
                ball.velocity = new Vector3(ballSpeed * paddleMultiplier, 0f, -ballSpeed * paddleMultiplier);
            }
            else if (leftPaddleBody.velocity.x < -0.1f)
            {
                ball.velocity = new Vector3(-ballSpeed * paddleMultiplier, 0f, -ballSpeed * paddleMultiplier);
            }
            else
            {
                // sends the ball in the opposite direction depending on where on the paddle the collision is
                if (distanceLeft > 0.5f)
                {
                    ball.velocity = new Vector3(ballSpeed * paddleMultiplier, 0f, -ballSpeed * paddleMultiplier);
                }
                else if (distanceLeft < -0.5f)
                {
                    ball.velocity = new Vector3(-ballSpeed * paddleMultiplier, 0f, -ballSpeed * paddleMultiplier);
                }
                else
                {
                    ball.velocity = new Vector3(0f, 0f, -ballSpeed * paddleMultiplier);
                }
            }
        }

        float distanceRight = ball.transform.position.x - rightPaddle.transform.position.x;

        if (collision.gameObject.name == "Right Player Paddle")
        {
            // sends the ball in the opposite direction depending on the velocity of the paddle
            if (rightPaddleBody.velocity.x > 0.1f)
            {
                ball.velocity = new Vector3(ballSpeed * paddleMultiplier, 0f, ballSpeed * paddleMultiplier);
            }
            else if (rightPaddleBody.velocity.x < -0.1f)
            {
                ball.velocity = new Vector3(-ballSpeed * paddleMultiplier, 0f, ballSpeed * paddleMultiplier);
            }
            else
            {
                // sends the ball in the opposite direction depending on where on the paddle the collision is
                if (distanceRight > 0.5f)
                {
                    ball.velocity = new Vector3(ballSpeed * paddleMultiplier, 0f, ballSpeed * paddleMultiplier);
                }
                else if (distanceRight < -0.5f)
                {
                    ball.velocity = new Vector3(-ballSpeed * paddleMultiplier, 0f, ballSpeed * paddleMultiplier);
                }
                else
                {
                    ball.velocity = new Vector3(0f, 0f, ballSpeed * paddleMultiplier);
                }
            }
        }
    }
}
