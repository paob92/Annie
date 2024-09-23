using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float minDistance;
    private int randomNumber; 
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        randomNumber = Random.Range(0, movementPoints.Length );
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flip();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[randomNumber].position, movementSpeed * Time.deltaTime );
        if(Vector2.Distance(transform.position, movementPoints[randomNumber].position)< minDistance)
        {
            randomNumber= Random.Range(0, movementPoints.Length);
            Flip();
        }
    }

    private void Flip()
    {
        if (transform.position.x < movementPoints[randomNumber].position.x) {
            spriteRenderer.flipX = true;
            
        }
        else
        {
            spriteRenderer.flipX= false;
        }


    }
}
