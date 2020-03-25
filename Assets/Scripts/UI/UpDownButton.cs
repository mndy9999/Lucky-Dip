using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpDownButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite buttonNormalSprite;
    public Sprite buttonHighlightSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = buttonHighlightSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = buttonNormalSprite;
    }
}
