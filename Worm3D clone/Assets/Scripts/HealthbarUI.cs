using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private Image healthbarSprite;

    private void Start() {
        healthbar = gameObject.transform.parent.GetComponentInChildren<Healthbar>();
    }

    private void Update() {
        healthbarSprite.fillAmount = healthbar.target;
    }
}
