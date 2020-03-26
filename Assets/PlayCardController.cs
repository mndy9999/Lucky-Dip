using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayCardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject playPanel;
    public Card UnknownCard;

    public BattleController battleController;

    private Card activeCard;

    public CardDisplay cardDisplay;

    Vector3 position, defaultPosition;
    Vector3 scale, defaultScale;

    private bool isDragging;

    // Start is called before the first frame update
    void Start()
    {
        position = defaultPosition = transform.position;
        scale = defaultScale = transform.localScale;
        activeCard = GetComponent<CardDisplay>().ActiveCard;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, position, 2);
        activeCard = GetComponent<CardDisplay>().ActiveCard;
        if (isDragging)
            transform.position = Input.mousePosition + new Vector3(-1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || activeCard.CardType == CardTypes.Unknown || isDragging)
            return;
        transform.SetAsLastSibling();
        position = defaultPosition + Vector3.up * 70;
        scale = defaultScale * 1.5f;
        transform.localScale = scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || activeCard.CardType == CardTypes.Unknown || isDragging)
            return;
        position = defaultPosition;
        scale = defaultScale;
        transform.localScale = scale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (activeCard.CardType == CardTypes.Unknown)
            return;
        isDragging = true;
        transform.GetComponent<RectTransform>().pivot = new Vector2(1.0f, 0.0f);
        transform.localScale = defaultScale * 0.5f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        if (playPanel.GetComponent<TrashCanHovered>().Hovered)
        {
            battleController.PlayCard(activeCard);
            playPanel.GetComponent<PanelController>().ShowEnemyCard(activeCard);
            transform.gameObject.SetActive(false);
        }
        
        transform.position = defaultPosition;
        transform.localScale = defaultScale;
        isDragging = false;
    }
}