using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchSpeedMultiplier = 0.5f;  
    public Vector2 crouchColliderSize = new Vector2(1f, 0.5f);  
    public Vector2 crouchColliderOffset = new Vector2(0f, -0.25f); 

    private BoxCollider2D playerCollider;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private float originalSpeed;
    private bool isCrouching = false;

    void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = playerCollider.size;
        originalColliderOffset = playerCollider.offset;

       
        originalSpeed = GetComponent<PlayerMovement>().speed;
    }

    void Update()
    {
        HandleCrouch();
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!isCrouching)
            {
                
                GetComponent<PlayerMovement>().speed *= crouchSpeedMultiplier;

               
                playerCollider.size = crouchColliderSize;
                playerCollider.offset = crouchColliderOffset;

                isCrouching = true;
            }
        }
        else if (isCrouching)
        {
            // Restaurar la velocidad del personaje al dejar de agacharse
            GetComponent<PlayerMovement>().speed = originalSpeed;

            // Restaurar el tamaño y el offset del collider
            playerCollider.size = originalColliderSize;
            playerCollider.offset = originalColliderOffset;

            isCrouching = false;
        }
    }
}
