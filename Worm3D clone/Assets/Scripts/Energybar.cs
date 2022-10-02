using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energybar : MonoBehaviour
{

    [SerializeField] private Image energybarSprite;
    private float target;

    public GameObject gameManager;
    public PlayerSwitchReference playerSwitchReference;

    private void Start() {
    playerSwitchReference = gameManager.GetComponent<PlayerSwitchReference>();
    }

    public void UpdateEnergyBar(float maxEnergy, float currentEnergy) 
    {
        target = currentEnergy / maxEnergy;
    }

    private void Update() {
        energybarSprite.fillAmount = target;
    }

}

