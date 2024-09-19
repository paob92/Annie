using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrap : MonoBehaviour
{
    [SerializeField] private Collider2D Collider2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Dead") || collision.gameObject.CompareTag("Ground"))
        {
            
            Collider2D.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
