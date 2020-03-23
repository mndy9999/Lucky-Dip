using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = (GameManager)FindObjectOfType(typeof(GameManager));
            return instance;
        }
    }

    public Node PlayerTilePosition;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void InitGame()
    {

    }
}




