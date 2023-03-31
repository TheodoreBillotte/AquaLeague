using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMessage : Goals
{

    private void Start()
    {
        GameManager _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Text _win = GameObject.Find("WinMessage").GetComponent<Text>();
        Text _score = GameObject.Find("Scores").GetComponent<Text>();
        _win.text = _manager._player1 == _manager._player2 ? "It's A Draw !" :
            _manager._player2 < _manager._player1 ? "Player Blue Won !" : "Player Red Won !";
        _score.text = "Scores : " + _manager._player1 + " - " + _manager._player2;
    }

}
