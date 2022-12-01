using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class RightPaddleAccelerate : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    [SerializeField] private float accelerateSpeed;
    [SerializeField] private float accelerateDuration;

    private PaddleMovement paddleMovement;

    private float paddleSpeed;

    public bool activateRightPaddleAccelerate = false;
    public bool usedRightPaddleAccelerate = false;

    private void Start()
    {
        paddleMovement = GetComponent<PaddleMovement>();
        paddleSpeed = paddleMovement.paddleSpeed;
    }

    private void Update()
    {
        if (activateRightPaddleAccelerate == true)
        {
            if (usedRightPaddleAccelerate == false)
            {
                activateRightPaddleAccelerate = false;
                StartCoroutine(PaddleAccelerate(accelerateDuration));
            }
        }
    }

    IEnumerator PaddleAccelerate(float duration)
    {
        // increases paddle speed for a specified duration
        paddleMovement.paddleSpeed = accelerateSpeed;
        yield return new WaitForSeconds(duration);
        paddleMovement.paddleSpeed = paddleSpeed;
        usedRightPaddleAccelerate = true;
    }
}
