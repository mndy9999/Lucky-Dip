using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDefeat : MonoBehaviour
{

    public GameObject winLoseUI;
    public TurnManager turnManager;
    public GameObject CombatUI;
    
    public void CheckDead(){
        if(PlayerStats.SCurrentHealth <= 0){
            Defeat();
        }
        if(EnemyStats.Health <= 0){
            Victory();
            
        }
        
    }

    void Defeat(){
        winLoseUI.transform.GetChild(1).gameObject.SetActive(true);
        Destroy(turnManager);
        CombatUI.SetActive(false);

    }

    void Victory(){
        winLoseUI.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(turnManager);
        CombatUI.SetActive(false);
    }
}

