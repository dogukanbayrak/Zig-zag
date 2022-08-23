using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;

    private Vector3 ballDirection;
    [SerializeField]  private bool turnCheck;
    

    void Start()
    {

        turnCheck = true;

        ballDirection = Vector3.left;
    } 


    void Update()
    {
        InputCheck();
        SetBallRotation();
        BallMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Faster"))
        {
            moveSpeed += .2f;
        }
        else if(collision.gameObject.CompareTag("Slower"))
        {
            moveSpeed -= .2f;
        }
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            turnCheck = !turnCheck;
        }
    }
    private void SetBallRotation()
    {
        if (turnCheck) 
        {
            ballDirection = Vector3.forward; 
        }
        else
        {
            ballDirection = Vector3.left;
        }
    }
    private void BallMovement()
    {
        transform.Translate(ballDirection * moveSpeed * Time.deltaTime);
    }

}