using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject collectWindow;

    public void CheckTileAt(Node tile)
    {
        if (tile.Collected)
            return;
        AudioManager.Instance.PlayPopSound();
        collectWindow.SetActive(true);
    }
}
