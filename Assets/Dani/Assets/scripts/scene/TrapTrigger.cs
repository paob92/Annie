using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject spike;
   
    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("Se detecto un collider");
        
        if (collision.CompareTag("Player"))
        {
            spike.SetActive(true); 
        }
    }
}
