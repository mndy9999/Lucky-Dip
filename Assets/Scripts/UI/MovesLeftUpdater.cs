using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesLeftUpdater : MonoBehaviour
{
    public TextMeshProUGUI movesText;
    public GameObject getMovesButton;

    private const string movesDefault = "Moves Left: {0}";
    private int mMovesLeft;
    private int MovesLeft
    {
        set
        {
            if(mMovesLeft != value)
            {
                mMovesLeft = value;
                UpdateText();
                getMovesButton.SetActive(value <= 0);
            }
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        MovesLeft = PlayerStats.Instance.MovesLeft;
    }

    // Update is called once per frame
    void UpdateText()
    {
        movesText.text = string.Format(movesDefault, PlayerStats.Instance.MovesLeft);
    }

    public void Roll16()
    {
        PlayerStats.Instance.MovesLeft = Random.Range(1, 7);
    }


}
