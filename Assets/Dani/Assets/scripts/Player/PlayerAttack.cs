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
    [SerializeField] private Animator animator;

    private bool isAttacking = false; 

    private void Update()
    {
        
        if (!isAttacking)
        {
            attackEffect.SetActive(false);
            animator.SetBool("Attack", false);
        }

        
        if (timeAttack > 0)
        {
            timeAttack -= Time.deltaTime;
        }

        
        if (Input.GetButtonDown("Fire1") && timeAttack <= 0)
        {
            StartCoroutine(Attack());
            timeAttack = attackCooldown;
        }
    }

    private IEnumerator Attack()
    {
        
        isAttacking = true;
        animator.SetBool("Attack", true);

        
        attackEffect.SetActive(true);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(attackController.position, attackRange);

       
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy") || colisionador.CompareTag("Ente"))
            {
                colisionador.transform.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        
        yield return new WaitForSeconds(0.25f);

       
        attackEffect.SetActive(false);
        isAttacking = false;
        animator.SetBool("Attack", false); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRange);
    }
}
