using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMessage : Goals
{
    private Text _text;
    private Text _score;

    private void Start()
    {
        _text = GameObject.Find("WinMessage").GetComponent<Text>();
        _score = GameObject.Find("Scores").GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = goalLeft.goals < goalRight.goals ? "Player Blue Won !!" : "Player Red Won !!";
        _score.text = "Scores : " + score.text;
    }
}
