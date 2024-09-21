using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackController;
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float timeAttack;
    [SerializeField] private GameObject attackEffect;

    

    private void Update()
    {
        attackEffect.SetActive(false);

        if (timeAttack > 0)
        {
            timeAttack -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && timeAttack <= 0)
        {
            Attack();
            timeAttack= attackCooldown;
        }
        
    }

    private void Attack()
    {
        attackEffect.SetActive(true);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(attackController.position, attackRange);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRange);
    }
}
