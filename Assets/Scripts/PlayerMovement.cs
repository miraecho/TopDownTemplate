using NUnit.Framework.Internal.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private bool playingFootSteps = false;
    public float footstepSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(PauseController.IsGamePaused) 
        {
            rb.linearVelocity = Vector2.zero; //Stop player movement
            animator.SetBool("IsWalking", false);
            StopFootsteps();
            return;
        }
        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("IsWalking", rb.linearVelocity.magnitude > 0);

        if (rb.linearVelocity.magnitude > 0 && !playingFootSteps) 
        {
            StartFootsteps();
        }
        else if (rb.linearVelocity.magnitude == 0) 
        {
            StopFootsteps();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled) 
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
            
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    void StartFootsteps() 
    {
        playingFootSteps = true;
        InvokeRepeating(nameof(PlayFootstep), 0f, footstepSpeed);
    }
    
    void StopFootsteps() 
    {
        playingFootSteps = false;
        CancelInvoke(nameof(PlayFootstep));
    }

    void PlayFootstep() 
    {
        SoundEffectManager.Play("Footstep", true);
    }
}
