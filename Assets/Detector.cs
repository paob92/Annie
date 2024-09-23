using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && boss != null)
        {
            boss.SetActive(true);
        } else
        {
            Debug.Log(" no esta perry");
        }
    }
}
