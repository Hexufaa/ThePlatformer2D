using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speedRun;

    public float speed;

    public float forceJump = 2;

    private float _currentSpeed;

    //private bool _isRunning = false;

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.X))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
        }

        if(myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity += friction;
        }else if(myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            myRigidBody.velocity = Vector2.up * forceJump;
        }
    }

}
