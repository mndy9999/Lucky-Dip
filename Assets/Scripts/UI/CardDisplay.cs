using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject trashCan;
    public Card UnknownCard;

    private Card mActiveCard;
    public Card ActiveCard
    {
        get
        {
            return mActiveCard;
        }
        set
        {
            mActiveCard = value != null ? value : UnknownCard;
            UpdateText();
        }
    }

    public bool isInWorldScene;


    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    public Text RollLow;
    public Text RollMed;
    public Text RollHigh;

    Vector3 position, defaultPosition;
    Vector3 scale, defaultScale;

    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        if(ActiveCard == null)
            ActiveCard = UnknownCard;

        position = defaultPosition = transform.position;
        scale = defaultScale = transform.localScale;

        UpdateText();
    }

    void UpdateText()
    {

        nameText.text = mActiveCard.Name;
        descriptionText.text = mActiveCard.Description;
        artworkImage.sprite = mActiveCard.Artwork;

        if(mActiveCard is BattleCard)
        {
            var desc = "";
            if(mActiveCard is AttackCard)
                desc = "Roll {0}-{1}: Deal {2} Attack Damage";
            else if(mActiveCard is AbilityCard)
                desc = "Roll {0}-{1}: Deal {2} Magic Damage";
            else if(mActiveCard is HealCard)
                desc = "Roll {0}-{1}: Heal {2} Points";

            var c = mActiveCard as BattleCard;
            RollLow.text = string.Format(desc, "1", "2", c.RollLow.ToString());
            RollMed.text = string.Format(desc, "3", "4", c.RollMed.ToString());
            RollHigh.text = string.Format(desc, "5", "6", c.RollHigh.ToString());
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!isInWorldScene)
            transform.position = Vector3.MoveTowards(transform.position, position, 2);
        if (isDragging)
            transform.position = Input.mousePosition + new Vector3(-1, 1);
    }



}
