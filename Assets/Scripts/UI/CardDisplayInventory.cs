using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDisplayInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Card activeCard;
    Vector3 position, defaultPosition;
    Vector3 scale, defaultScale;

    public GameObject trashCan;
    private bool isDragging;

    void Start()
    {
        position = defaultPosition = transform.position;
        scale = defaultScale = transform.localScale;
        activeCard = GetComponent<CardDisplay>().ActiveCard;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (isDragging)
            transform.position = Input.mousePosition + new Vector3(-1, 1);

        transform.position = Vector3.MoveTowards(transform.position, position, 2);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || !activeCard.Discovered || GameManager.Instance.IsCollecting)
            return;
        transform.SetAsLastSibling();
        position = defaultPosition + Vector3.up * 70;
        scale = defaultScale * 1.5f;
        transform.localScale = scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) || !activeCard.Discovered)
            return;
        position = defaultPosition;
        scale = defaultScale;
        transform.localScale = scale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!activeCard.Discovered)
            return;
        GameManager.Instance.IsDragging = isDragging = true;
        transform.GetComponent<RectTransform>().pivot = new Vector2(1.0f, 0.0f);
        transform.localScale = defaultScale * 0.5f;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        if (GameManager.Instance.IsInWorldScene && trashCan.GetComponent<TrashCanHovered>().Hovered && PlayerInventory.Instance.AvailableCards.Count > 3)
            PlayerInventory.Instance.RemoveCard(activeCard);
        GameManager.Instance.IsDragging = isDragging = false;
        transform.position = position = defaultPosition;
        transform.localScale = defaultScale;
    }
}
