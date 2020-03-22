using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomRolls : MonoBehaviour
{

    public Text ResultsText;
    private GameplayManager gameplayManager;

    public void Start()
    {
        gameplayManager = GetComponent<GameplayManager>();
    }

    public void Roll16()
    {
        var rand = Random.Range(1, 7);
        ResultsText.text = rand.ToString();
        gameplayManager.ShowHideCanvas(rand);
    }

    public void Update()
    {

    }

}
