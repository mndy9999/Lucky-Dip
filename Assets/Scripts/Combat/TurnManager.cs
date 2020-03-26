using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{   
    //this file is primarially running the players turn

    //public PlayerStats playerStats;
    public EnemyStats enemyStats;
    WinDefeat winDefeat;

    public struct Stats{
        public int a;
        public int b;
        public int c;
        public Stats(int a1,int b1, int c1){
            a = a1;
            b = b1;
            c = c1;
        }
    }
    public Stats stats;

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
        winDefeat = gameObject.GetComponent<WinDefeat>();
        yourTurn = true;
        HpText.SetText("Hp "+ PlayerStats.SCurrentHealth);
        BadyHpText.SetText("Hp "+ EnemyStats.Health);
    }

    

    public void CardSeleted(CardDisplay Card)
    {
        int self=0, foe=0, test= PlayerStats.SAttackPower;
        
       if(yourTurn){
            stats = new Stats(PlayerStats.SAttackPower,PlayerStats.SAbilityPower,PlayerStats.SHealingPower);
        }else{
            stats = new Stats(enemyStats.AttackPower,enemyStats.AbilityPower,enemyStats.HealingPower);
        }
       


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
                foe -= actionPoten + stats.a ;  
                break;
            case "Ability":
                foe -= actionPoten + stats.b ;  
                break;
            case "Healing":
                self += actionPoten + stats.c ;
                break;
            case "RideOrDie":
                if(diceRoll>3){
                    foe -= actionPoten ;
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
            PlayerStats.SCurrentHealth += self;
            EnemyStats.Health += foe;
            
        }else{
            PlayerStats.SCurrentHealth += foe;
            EnemyStats.Health += self;
        }

        BadyHpText.SetText("Hp "+ EnemyStats.Health);
        HpText.SetText("Hp "+ PlayerStats.SCurrentHealth);
        //print(pickedCard.name + " " + pickedCard.CardType + " " + actionPoten);


        winDefeat.CheckDead();
        Card.ReplaceCard();

        // Disable/Enable players cards
        yourTurn = !yourTurn;
        for(int i=0; i<controls.Count; i++)
        {
            controls[i].GetComponent<UnityEngine.UI.Button>().interactable = yourTurn;
        }

        

        if (!yourTurn)
            enemyStats.EnemyTurn();
        
        //once my turn is over disable my deck and run enemies turn
    }  
}
