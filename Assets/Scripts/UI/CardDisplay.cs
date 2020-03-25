using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
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

        string desc;
        switch (mActiveCard.CardType)
        {
            case CardTypes.Attack:
                desc = "Roll {0}-{1}: Deal {2} Attack Damage";
                break;
            case CardTypes.Ability:
                desc = "Roll {0}-{1}: Deal {2} Magic Damage";
                break;
            case CardTypes.Healing:
                desc = "Roll {0}-{1}: Heal {2} Points";
                break;
            default:
                desc = "";
                break;
        }


        RollLow.text = string.Format(desc, "1", "2", mActiveCard.RollLow.ToString());
        RollMed.text = string.Format(desc, "3", "4", mActiveCard.RollMed.ToString());
        RollHigh.text = string.Format(desc, "5", "6", mActiveCard.RollHigh.ToString());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!isInWorldScene)
            transform.position = Vector3.MoveTowards(transform.position, position, 2);
        if (isDragging)
            transform.position = Input.mousePosition + new Vector3(-1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || ActiveCard.CardType == CardTypes.Unknown || GameManager.Instance.IsCollecting)
            return;
        transform.SetAsLastSibling();
        position = defaultPosition + Vector3.up * 70;
        scale = defaultScale * 1.5f;
        transform.localScale = scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || ActiveCard.CardType == CardTypes.Unknown)
            return;
        position = defaultPosition;
        scale = defaultScale;
        transform.localScale = scale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ActiveCard.CardType == CardTypes.Unknown)
            return;
        GameManager.Instance.IsDragging = isDragging = true;
        transform.GetComponent<RectTransform>().pivot = new Vector2(1.0f, 0.0f);
        transform.localScale = defaultScale * 0.5f;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        if (GameManager.Instance.IsInWorldScene && trashCan.GetComponent<TrashCanHovered>().Hovered && PlayerInventory.Instance.AvailableCards.Count > 3)
            ActiveCard.CardType = CardTypes.Unknown;
        GameManager.Instance.IsDragging = isDragging = false;
        transform.position = defaultPosition;
        transform.localScale = defaultScale;
    }

}
