using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;

    private Vector3 ballDirection;
    [SerializeField]  private bool turnCheck;

    public GameManager gameManager;

    public float pointMultiplier=1f;


    void Start()
    {
        moveSpeed = 5f;
        pointMultiplier = 1;
        turnCheck = true;

        ballDirection = Vector3.left;
    } 


    void Update()
    {
        InputCheck();
        SetBallRotation();
        BallMovement();
        Restart();
        MoveSpeedFixer();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Faster"))
        {
            moveSpeed += .2f;
            pointMultiplier += .2f;
        }
        else if(collision.gameObject.CompareTag("Slower"))
        {
            moveSpeed -= .2f;
            pointMultiplier -= .2f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Faster") || collision.gameObject.CompareTag("Slower") || collision.gameObject.CompareTag("Ground"))
        {
            
            gameManager.groundCounter++;

            gameManager.GainPoint();
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
    public void Restart()
    {
        if (gameObject.transform.position.y < -5)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void MoveSpeedFixer()
    {
        if (moveSpeed > 10)
        {
            moveSpeed = 10;
        }
        else if (moveSpeed < 3.8f)
        {
            moveSpeed = 3.8f;
        }
    }


}