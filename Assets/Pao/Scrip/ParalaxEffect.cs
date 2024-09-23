using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private Vector2 speedMovement;

    private Vector2 offset;
    private Material materialBackground;
    private Rigidbody2D playerRB;

    private void Awake()
    {
        materialBackground = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        offset = (playerRB.velocity.x *0.1f) * speedMovement *  Time.deltaTime;  
        materialBackground.mainTextureOffset += offset;
    }
}
