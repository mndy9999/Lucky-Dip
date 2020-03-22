using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    public Text RollLow;
    public Text RollMed;
    public Text RollHigh;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.Name;
        descriptionText.text = card.Description;
        artworkImage.sprite = card.Artwork;

        string desc;
        switch (card.CardType) {
            case Card.CardTypes.Attack:
                desc = "Roll {0}-{1}: Deal {2} Attack Damage";
                break;
            case Card.CardTypes.Ability:
                desc = "Roll {0}-{1}: Deal {2} Magic Damage";
                break;
            case Card.CardTypes.Healing:
                desc = "Roll {0}-{1}: Heal {2} Points";
                break;
            default:
                desc = "";
                break;
        }


        RollLow.text = string.Format(desc, "1", "2", card.RollLow.ToString());
        RollMed.text = string.Format(desc, "3", "4", card.RollMed.ToString());
        RollHigh.text = string.Format(desc, "5", "6", card.RollHigh.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
