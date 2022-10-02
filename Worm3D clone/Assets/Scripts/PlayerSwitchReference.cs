using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchReference : MonoBehaviour
{
  
    public GameObject playerPrefab;

    public Transform direction;
    public Transform player;
    public Transform playerModel;
    public Rigidbody rb;
    public Transform combatLookAt;
    public Transform weapon;
    public Transform mainFirePoint;

    void Start()
    {
        playerPrefab = GameObject.FindWithTag("CurrentPlayer");
    }
    void Update()
    {
        playerPrefab = GameObject.FindWithTag("CurrentPlayer");
        if (playerPrefab.tag == "CurrentPlayer")
        {
            direction = playerPrefab.transform.Find("Direction").transform;
            player = playerPrefab.transform;
            playerModel = playerPrefab.transform.Find("PlayerModel").transform;
            rb = playerPrefab.transform.GetComponent<Rigidbody>();
            combatLookAt = direction.transform.Find("CombatLookAt").transform;
            weapon = direction.transform.Find("Weapon").transform;
            mainFirePoint = weapon.transform.Find("ProjectileOrigin").transform;
        }
        else 
        {
            direction = null;
            player = null;
            playerModel = null;
            rb = null;
            combatLookAt = null;
            weapon = null;
            mainFirePoint = null;
        }
    }
}

