using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;

    //put this variable on playercontroller
    private int currentPlayerIndex;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
        } 
    }

    public bool IsItPlayerTurn(int index)
    {
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeTurn();
        }
    }
}
