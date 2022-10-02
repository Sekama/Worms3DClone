using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private Healthbar healthbar;
    [SerializeField] private Healthbar healthbarUI;
    [SerializeField] private Canvas healthbarCanvas;
    [SerializeField] private Canvas healthbarUICanvas;

    private void Start() {
        currentHealth = maxHealth;

        healthbar.UpdateHealthBar(maxHealth,currentHealth);
        healthbarCanvas = healthbar.GetComponent<Canvas>();
        healthbarUICanvas = healthbarUI.GetComponent<Canvas>();
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.UpdateHealthBar(maxHealth,currentHealth);

        if (currentHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (transform.tag == "CurrentPlayer")
        {
            healthbarCanvas.enabled = false;
            healthbarUICanvas.enabled = true;
        }
        else 
        { 
            healthbarCanvas.enabled = true;
            healthbarUICanvas.enabled = false;
        }
    }

    private void OnDestroy() {
        GameManager.Instance.players.Remove(this.gameObject);
    }
    
}
