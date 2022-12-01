using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class RightPaddleFastBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;
    [SerializeField] private float fastDelay;
    [SerializeField] private float fastSpeed;

    public bool activateRightFastBall = false;
    public bool usedRightFastBall = false;

    private void FastBall()
    {
        // applies forces to the ball to make it move faster
        if (ballBody.velocity.x != 0)
        {
            ballBody.AddForce(ball.transform.position.x, 0, fastSpeed * 100, ForceMode.Force);
            usedRightFastBall = true;
        }
        else if (ballBody.transform.position.x == 0)
        {
            ballBody.AddForce(0, 0, fastSpeed * 100, ForceMode.Force);
            usedRightFastBall = true;
        }
        else
        {
            ballBody.AddForce(0, 0, fastSpeed * 100, ForceMode.Force);
            usedRightFastBall = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // increases ball speed once the it collides with the paddle
        if (activateRightFastBall == true)
        {
            if (usedRightFastBall == false)
            {
                if (collision.gameObject == ball)
                {
                    Invoke("FastBall", fastDelay);
                }
            }
        }
    }
}
