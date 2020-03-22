using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public GameObject canvas;
    public PlayerStats playerStats;

    private int mPlayerMoves;
    public int PlayerMoves
    {
        get
        {
            return playerStats.MovesLeft;
        }
        set
        {
            if(value != mPlayerMoves)
            {
                mPlayerMoves = value;
                if(value <= 0)
                {
                    ShowHideCanvas();
                }
            }
        }
    }

    private void Start()
    {
        ShowHideCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoves = playerStats.MovesLeft;
    }

    public void ShowHideCanvas(int moves = 0)
    {
        StartCoroutine(ShowHideCanvasAfterSeconds(2.0f, moves));
    }

    private IEnumerator ShowHideCanvasAfterSeconds(float time, int moves)
    {
        yield return new WaitForSecondsRealtime(time);
        canvas.SetActive(!canvas.activeSelf);
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        if(moves >= 0)
            playerStats.MovesLeft = moves;
    }

}
