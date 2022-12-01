using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    [SerializeField] private Rigidbody paddle;

    [SerializeField] public float paddleSpeed;

    void Start()
    {
        paddle = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // the paddle moves vertically at a constant speed
        if (Input.GetKey(upKey))
        {
            paddle.velocity = new Vector3(paddleSpeed, 0f, 0f);
        }
        else if(Input.GetKey(downKey))
        {
            paddle.velocity = new Vector3(-paddleSpeed, 0f, 0f);
        }
        else
        {
            paddle.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
