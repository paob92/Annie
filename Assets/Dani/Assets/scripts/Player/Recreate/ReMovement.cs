using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class ReMovement : MonoBehaviour
{
    private Rigidbody2D rigid;

    [Header("movimiento")]
    private float horizontalMove;
    [SerializeField] private float Speed;
    [SerializeField] private float smoothMovement;
    private Vector3 velocidad = Vector3.zero;
    private bool lookRigth = true;

    [Header("jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundController;
    [SerializeField] private Vector3 boxDimension;
    [SerializeField] private bool isGround;
    private bool jump = false;

    [Header("Animation")]
    [SerializeField] private Animator animator;

   /* [Header(" Audio")]
   [SerializeField] private AudioSource audioSource;
    public AudioClip walkSound;*/

    /*private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }*/

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GetComponent<Animator>();
    }
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
        

        animator.SetFloat("Horizontal" , Mathf.Abs(horizontalMove));
       /* if (horizontalMove != 0 && !audioSource.isPlaying && isGround)
        {
            audioSource.clip = walkSound;
            audioSource.Play(); 
        }
        else if (horizontalMove == 0 && audioSource.isPlaying || !isGround)
        {
            audioSource.Stop(); 
        }*/
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(groundController.position, boxDimension, 0f, ground);
        animator.SetBool("Grounded", isGround);

        Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void Move(float move, bool jumping)
    {
        Vector3 targetSpeed = new Vector2(move, rigid.velocity.y);
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, targetSpeed, ref velocidad, smoothMovement);
        if (move > 0 && !lookRigth)
        {
            Spin();

        }
        else if (move < 0 && lookRigth)
        {
            Spin();
        }
        if (isGround && jumping)
        {
            isGround = false;
            rigid.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Spin()
    {
        lookRigth = !lookRigth;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundController.position, boxDimension);
    }
}

