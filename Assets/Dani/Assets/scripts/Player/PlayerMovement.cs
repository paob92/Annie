using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidPlayer;

    void Awake()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float inputMovement = Input.GetAxis("Horizontal");
        rigidPlayer.velocity = new Vector2(inputMovement * speed, rigidPlayer.velocity.y);
        Flip(inputMovement);
    }

    void Flip(float inputMovement)
    {
        if ((inputMovement > 0 && rigidPlayer.transform.localScale.x < 0) || (inputMovement < 0 && rigidPlayer.transform.localScale.x > 0))
        {
            Vector3 scale = rigidPlayer.transform.localScale;
            scale.x *= -1;
            rigidPlayer.transform.localScale = scale;
        }
    }
}
