using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tileCardUI;
    public EnemyType enemyType;

    public void Start()
    {
        enemyType = (EnemyType)Random.Range(1, 4);
    }
    void OnMouseOver()
    {
        tileCardUI.GetComponent<CardDisplay>().EnemyType = GetComponent<Node>().SteppedOn ? enemyType : EnemyType.Unknown;
        tileCardUI.SetActive(true);
    }

    void OnMouseExit()
    {
        tileCardUI.SetActive(false);
    }
}
