using System.Collections;
using UnityEngine;

public class ShootIA : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoot;
    [SerializeField] private Transform player;  

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShoot);

           
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.SetTarget(player); 
            }
        }
    }
}
