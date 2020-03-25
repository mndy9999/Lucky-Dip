using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;
    public CardDisplay cardDisplay;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardDisplay.ActiveCard = card;
        cardDisplay.transform.position = Input.mousePosition + new Vector3(1, -1);
        cardDisplay.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if(cardDisplay.gameObject.activeSelf)
            cardDisplay.transform.position = Input.mousePosition + new Vector3(10, 10);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardDisplay.gameObject.SetActive(false);
    }
}
