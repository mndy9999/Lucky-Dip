using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{   
    //this file is primarially running the players turn

    public EnemyStats enemyStats;
    public List<GameObject> controls;
    public Card pickedCard;
    
    public bool yourTurn;
    private int actionPoten;

    public int diceRoll;
    public TextMeshProUGUI DiceText;
    
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI BadyHpText;

    
    void Awake()
    {

        yourTurn = true;
        HpText.SetText("Hp "+ PlayerStats.CurrentHealth);
        BadyHpText.SetText("Hp "+ EnemyStats.Health);
    }

    



    public void CardSeleted(CardDisplay Card)
    {
        int self=0, foe=0;
          
        diceRoll = Random.Range(1,7);
        DiceText.SetText( ""+ diceRoll);
        

        //looks through CardDisplay's list and finds the picked card
        pickedCard = Card.cards.Find(x=> x.name == Card.nameText.text);
        
        // Shortened if statments to determine the roll dmg
        actionPoten = diceRoll>4? pickedCard.RollHigh:diceRoll<3? pickedCard.RollLow:pickedCard.RollMed;
  
        // Determine what kind of effect actionPoten will have
        switch(pickedCard.CardType.ToString())
        {
            case "Attack":
            case "Ability":
                foe -= actionPoten;  
                break;
            case "Healing":
                self += actionPoten;
                break;
            case "RideOrDie":
                if(diceRoll>3){
                    foe -= actionPoten;
                }else{
                    self += actionPoten;
                }
                break;
            default:
                print("error");
                break;
        }

        // refresh Hp(s)
        if(yourTurn){
            PlayerStats.CurrentHealth += self;
            EnemyStats.Health += foe;
            
        }else{
            PlayerStats.CurrentHealth += foe;
            EnemyStats.Health += self;
        }

        BadyHpText.SetText("Hp "+ EnemyStats.Health);
        HpText.SetText("Hp "+ PlayerStats.CurrentHealth);

        print(pickedCard.name + " " + pickedCard.CardType + " " + actionPoten);

        yourTurn = !yourTurn;
        // Disable/Enable players cards
        for(int i=0; i<controls.Count; i++)
        {
            controls[i].GetComponent<UnityEngine.UI.Button>().interactable = yourTurn;
        }

        if (!yourTurn)
            enemyStats.EnemyTurn();
        //once my turn is over disable my deck and run enemies turn
    }  
}
