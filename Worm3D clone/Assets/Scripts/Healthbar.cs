using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    [SerializeField] private Image healthbarSprite;
    [SerializeField] private float reduceSpeed;
    public float target;

    private Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth) 
    {
        target = currentHealth / maxHealth;
    }

    private void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

}
