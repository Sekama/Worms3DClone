using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private float maxEnergy;
    [SerializeField] public float currentEnergy;
   
    [SerializeField] private Energybar energybar;
    [SerializeField] private Canvas energybarCanvas;


    private void Start() {
        currentEnergy = maxEnergy;

        energybar.UpdateEnergyBar(maxEnergy,currentEnergy);
        energybarCanvas = energybar.GetComponent<Canvas>();
    }

    private void Update() {
        if (gameObject.tag != "CurrentPlayer")
        {
            currentEnergy = maxEnergy;
          //  energybar.UpdateEnergyBar(maxEnergy,currentEnergy);
        }
        if (gameObject.tag == "CurrentPlayer")
        {
            energybar.UpdateEnergyBar(maxEnergy, currentEnergy);
        }
    }


    public void PlayerUseEnergy(float energyCost) 
    {
        currentEnergy -= energyCost;
        energybar.UpdateEnergyBar(maxEnergy, currentEnergy);
    }
}
