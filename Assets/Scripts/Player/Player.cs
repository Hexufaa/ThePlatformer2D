using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speedRun;
    public float speed;
    public float forceJump = 2;
    private float _currentSpeed;



    [Header("Player anim")]
    public string boolRun = "Run";
    public Animator animator;

    //private bool _isRunning = false;

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

        

// to do: add the flip to the player



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
            animator.SetBool(boolRun, true);
            transform.localScale = new Vector3(-1, 1, 1);
 
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            animator.SetBool(boolRun, true);
            transform.localScale = new Vector3(1, 1, 1);
   
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        myRigidBody.rotation = Mathf.Clamp(myRigidBody.rotation, -30f, 30f);


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
