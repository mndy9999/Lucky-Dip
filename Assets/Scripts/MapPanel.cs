using UnityEngine;
using UnityEngine.EventSystems;

public class MapPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Pathfinding pathfinding;

    public void OnPointerEnter(PointerEventData eventData)
    {
        pathfinding.IsLookingAtMap = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pathfinding.IsLookingAtMap = false;
    }

}
