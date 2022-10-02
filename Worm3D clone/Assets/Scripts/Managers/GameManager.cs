using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> players = new List<GameObject>();
 
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        Instance = this;
    }

    private void Start() 
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(player);
        }

        UpdateGameState(GameState.GameSetup);
    }

    public void UpdateGameState(GameState newState) {
        State = newState;
        
        switch(newState) {
            case GameState.MainMenu:
                break;
            case GameState.GameSetup:
                HandleSetup();
                break;
            case GameState.NextTurn:
                HandleNextTurn();
                break;    
            case GameState.DecideWinner:
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Defeat:
                break;            
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
    //lazy setup
    private void HandleSetup() {
        int teamPicker = UnityEngine.Random.Range(0,100);
        if (teamPicker <= 50)
        {
            players[0].tag = "CurrentPlayer";
        }
        else
        {
            players[1].tag = "CurrentPlayer";
        }
    }
    //lazy turn changer
     private async void HandleNextTurn()
    {
        await Task.Delay (1000);

        if (players.Count == 1)
        {
            UpdateGameState(GameState.Victory);
        }
        else
        {
            await Task.Delay (1000);
            if(players[0].tag == "CurrentPlayer")
            {
                players[0].tag = "Player";
                players[1].tag = "CurrentPlayer";
            }
        
            else if(players[1].tag == "CurrentPlayer")
            {
                players[1].tag = "Player";
                players[0].tag = "CurrentPlayer";
            }   
        }
    }


    private void HandleVictory()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateGameState(GameState.NextTurn);
        }
    }
}

    public enum GameState 
    {
        MainMenu,
        GameSetup,
        NextTurn,
        DecideWinner,
        Victory,
        Defeat
    }

