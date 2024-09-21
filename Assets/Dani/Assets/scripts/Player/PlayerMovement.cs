using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private AudioSource audioSourceWalk; // Componente AudioSource
    private Rigidbody2D rigidPlayer;

    [Header("Animacion")]
    private Animator animator;
    void Awake()

    {
        animator = GetComponent<Animator>();
        rigidPlayer = GetComponent<Rigidbody2D>();
        audioSourceWalk = GetComponent<AudioSource>(); // Obtiene el componente AudioSource
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        
        float inputMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs( speed) );
        rigidPlayer.velocity = new Vector2(inputMovement * speed, rigidPlayer.velocity.y);
        Flip(inputMovement);

        // Reproduce el sonido de caminar si hay movimiento
        if (inputMovement != 0 && !audioSourceWalk.isPlaying)
        {
            audioSourceWalk.Play(); // Reproduce el sonido
        }
        else if (inputMovement == 0 && audioSourceWalk.isPlaying)
        {
            audioSourceWalk.Stop(); // Detiene el sonido si no hay movimiento
        }
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