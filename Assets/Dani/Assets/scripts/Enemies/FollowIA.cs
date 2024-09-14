using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private HealthPlayer healthPlayer;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private Dialogue Dialogue;
    private float nextAttackTime = 0f;  

    private void Update()
    {
        if (healthPlayer != null && !healthPlayer.isDead)
        {
            Follow();
        }
    }

    private void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > distance && !Dialogue.Dialoguing)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) <= distance && Time.time >= nextAttackTime)
        {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            
        }
    }

    private void Attack()
    {
        healthPlayer.TakeDamage(30f);
        Debug.Log("Ataque realizado");
    }
}