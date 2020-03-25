using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject[] ShowHideOnSceneLoad;


    public bool IsPaused;
    public bool IsDragging;
    public bool IsCollecting;
    public bool IsInWorldScene
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex == 1;
        }
    }

    public Node PlayerTilePosition;

    public GameObject Enemy;

    // Update is called once per frame
    public void LoadBattleScene()
    {
        SceneManager.LoadScene(3);
        foreach(var go in ShowHideOnSceneLoad)
        {
            go.SetActive(false);
        }
    }

    public void LoadMapScene()
    {
        PlayerStats.Instance.DoubleDamage = false;
        PlayerStats.Instance.DoubleHealth = false;
        SceneManager.LoadScene(1);
        foreach (var go in ShowHideOnSceneLoad)
        {
            go.SetActive(true);
        }
    }

}




