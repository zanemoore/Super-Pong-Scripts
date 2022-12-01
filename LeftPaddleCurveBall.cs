using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Darius/Zane
public class LeftPaddleCurveBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;

    [SerializeField] private float curveDelay;
    [SerializeField] private int curveSpeed;

    public bool activateLeftCurveBall = false;
    public bool usedLeftCurveBall = false;

    // called only when paddle power up is active
    public void CurveBall()
    {
        // applies forces to the ball to make it curve
        if (ballBody.velocity.x > 0)
        {
            ballBody.AddForce(-curveSpeed * 2, 0, 0, ForceMode.Force);
        }
        else if (ballBody.velocity.x < 0)
        {
            ballBody.AddForce(curveSpeed * 2, 0, 0, ForceMode.Force);
        }
        else
        {
            if (ballBody.transform.position.x >= 0)
            {
                ballBody.AddForce(-curveSpeed, 0, 0, ForceMode.Force);
            }
            else if (ballBody.transform.position.x <= 0)
            {
                ballBody.AddForce(curveSpeed, 0, 0, ForceMode.Force);
            }
        }

        ///Debug.Log("Ending Curve");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // activates a delayed curve once the ball collides with the paddle
        if (activateLeftCurveBall == true)
        {
            if (usedLeftCurveBall == false)
            {
                ///Debug.Log(collision, ball);
                if (collision.gameObject == ball)
                {
                    usedLeftCurveBall = true;
                    Invoke("CurveBall", curveDelay);
                    ///Debug.Log("Starting Curve");
                }
            }
        }
    }
}
