using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;

    public Vector2 friction = new Vector2(.1f, 0);
    public PlayerSetup playerSetup;

    /*public float speedRun;
    public float speed;
    public float forceJump = 2;*/
    private float _currentSpeed;

    //public SOFloat forceJump;


    [Header("Player anim")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;
    private HealthBase healthBase;
    public ParticleSystem jumpVFX;

    //private bool _isRunning = false;

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void PlayJumpVFX() 
    {
        if (jumpVFX != null) jumpVFX.Play();
    }

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
            animator.SetTrigger(triggerDeath);
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.X))
        {
            _currentSpeed = playerSetup.speedRun;
        }
        else
        {
            _currentSpeed = playerSetup.speed;
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
            myRigidBody.velocity = Vector2.up * playerSetup.forceJump;
            PlayJumpVFX();
        }

    }

}
