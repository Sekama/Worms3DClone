using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager Instance;
    
    void Awake() {
        Instance = this;
    }


public GameObject unit;

[System.Serializable]
    public class Units 
    {
        public List<GameObject> units;
    }  

[System.Serializable]
    public class Teams 
    {
        public List<Units> teams;
    }
   
     public Teams teamList = new Teams();
    

    private void Start() 
    {
        teamList.teams[0].units.Add(unit);
        
    }

}
