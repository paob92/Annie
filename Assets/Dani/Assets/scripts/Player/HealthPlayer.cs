using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverPanel;
    public bool isDead = false;

    
    public Transform[] checkpoints; 
    private int currentCheckpoint = 0; 
    private int deathCount = 0; 
    private int maxRespawns = 4; 

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealth();
        gameOverPanel.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(15f);
        }
        else if (collision.gameObject.CompareTag("Heal"))
        {
            Heal(10f);
        }
        else if (collision.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(10f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);
        }
        else if (collision.gameObject.CompareTag("Dead"))
        {
            TakeDamage(100f);
        }
        else if (collision.gameObject.CompareTag("Ente"))
        {
            TakeDamage(10f);
        }
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;
        UpdateHealth();

        if (currentHealth <= 0)
        {
            OnPlayerDeath();
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
        UpdateHealth();
    }

    public void OnPlayerDeath()
    {
        deathCount++;
        if (deathCount <= maxRespawns)
        {
            RespawnPlayer(); 
        }
        else
        {
            GameOver(); 
        }
    }

    public void RespawnPlayer()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealth();
        transform.position = checkpoints[currentCheckpoint].position; 
    }

    public void GameOver()
    {
        isDead = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReachCheckpoint(int checkpointIndex)
    {
        if (checkpointIndex > currentCheckpoint)
        {
            currentCheckpoint = checkpointIndex;
            
        }
    }

    public void UpdateHealth()
    {
        healthText.text = currentHealth + "/" + maxHealth + " HP";
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (other.transform == checkpoints[i])
                {
                    ReachCheckpoint(i);
                    break;
                }
            }
        }
    }
}
