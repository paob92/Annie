using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;  
    private Rigidbody2D rgb;
    [SerializeField] private Dialogue Dialogue;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        
        
            LaunchProjectile();  
        
        
    }

    public void SetTarget(Transform target)  
    {
        player = target;
    }

    private void LaunchProjectile()
    {
        if (!Dialogue.Dialoguing) {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            rgb.velocity = directionToPlayer * speed;
            StartCoroutine(DestroyProjectile());
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);  
    }
}
