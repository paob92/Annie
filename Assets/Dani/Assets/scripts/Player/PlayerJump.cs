using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpforce;
    public float range;
    public LayerMask layerGround;

    private Rigidbody2D rigidPlayer;
    private int jumpsRemaining = 1;

    void Awake()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (IsFloor() || jumpsRemaining > 0))
        {
            rigidPlayer.velocity = new Vector2(rigidPlayer.velocity.x, jumpforce);
            jumpsRemaining--;
        }

        if (IsFloor())
        {
            jumpsRemaining = 1;
        }
    }

    bool IsFloor()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, range, layerGround);
    }
}

