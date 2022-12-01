using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class LeftPaddleGrow : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    [SerializeField] private float growSize;
    [SerializeField] private float growDuration;

    private float paddleSize;

    public bool activateLeftPaddleGrow = false;
    public bool usedLeftPaddleGrow = false;

    private void Start()
    {
        paddleSize = transform.localScale.y;
    }

    private void Update()
    {
        if (activateLeftPaddleGrow == true)
        {
            if (usedLeftPaddleGrow == false)
            {
                activateLeftPaddleGrow = false;
                StartCoroutine(PaddleGrow(growDuration));
            }
        }
    }

    IEnumerator PaddleGrow(float duration)
    {
        // increases paddle length for a specified duration
        paddle.transform.localScale = new Vector3(1f, growSize, 1f);
        yield return new WaitForSeconds(duration);
        paddle.transform.localScale = new Vector3(1f, paddleSize, 1f);
        usedLeftPaddleGrow = true;
    }
}
