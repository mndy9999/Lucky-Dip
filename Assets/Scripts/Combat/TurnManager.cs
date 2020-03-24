using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    
    List<Button> controls;
    public Card pickedCard;
    
    public static int playerHp = 12;
    private int enemyHp;

    public static bool yourTurn;
    public int actionPoten;

    public int diceRoll;
    public TextMeshProUGUI DiceText;
    
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI BadyHpText;

    
    void Start()
    {
        // I will Generate the enemies Deck and Hp
        enemyHp = Random.Range(playerHp-4,playerHp+4);

        
        yourTurn = true;
        HpText.SetText("Hp "+ playerHp);
        BadyHpText.SetText("Hp "+ enemyHp);

    }
    public void CardSeleted(CardDisplay Card)
    {
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
                enemyHp = enemyHp - actionPoten;  
                break;
            case "Healing":
                playerHp = playerHp + actionPoten;
                break;
            case "RideOrDie":
                if(diceRoll>3){
                    enemyHp = enemyHp - actionPoten;
                }else{
                    enemyHp = enemyHp - actionPoten;
                }
                break;
            default:
                print("error");
                break;
        }

        // refresh Hp(s)
        BadyHpText.SetText("Hp "+ enemyHp);
        HpText.SetText("Hp "+ playerHp);

        yourTurn = false;

        print(pickedCard.CardType + " " + actionPoten);
    }

    void enemyTurn()
    {
        
    }
    
}
