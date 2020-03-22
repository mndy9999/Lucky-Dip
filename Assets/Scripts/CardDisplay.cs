using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    public Text RollLow;
    public Text RollMed;
    public Text RollHigh;

    Vector3 position, defaultPosition;
    Vector3 scale, defaultScale;

    public void OnPointerEnter(PointerEventData eventData)
    {
        position = defaultPosition + Vector3.up*70;
        scale = defaultScale * 1.5f;
        transform.localScale = scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        position = defaultPosition;
        scale = defaultScale;
        transform.localScale = scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        position = defaultPosition = transform.position;
        scale = defaultScale = transform.localScale;
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
        transform.position = Vector3.MoveTowards(transform.position, position, 2);

    }
}
