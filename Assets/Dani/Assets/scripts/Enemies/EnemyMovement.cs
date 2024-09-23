using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float minDistance;
    private int randomNumber;
    

    private void Start()
    {
        randomNumber = Random.Range(0, movementPoints.Length);
        
       
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[randomNumber].position, movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movementPoints[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, movementPoints.Length);
            
        }
    }

    
    }



