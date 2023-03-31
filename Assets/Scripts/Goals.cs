using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goals : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private GameObject _game;
    public Text score;
    public Goals goalLeft;
    public Goals goalRight;
    public GameManager _manager;

    void Start()
    {
        _game = GameObject.Find("GAME");
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        score = GameObject.Find("Scores").GetComponent<Text>();
        goalLeft = GameObject.Find("GOAL L").GetComponent<Goals>();
        goalRight = GameObject.Find("GOAL R").GetComponent<Goals>();
    }

    private void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.name == "Ball")
        {
            ball.transform.position = new Vector3(0, -5, 0);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            
            player1.GetComponent<PlayerController>().ResetPosition();
            player2.GetComponent<PlayerController>().ResetPosition();
            
            if (gameObject.name == "GOAL L")
                _manager._player2++;
            else
                _manager._player1++;
            score.text = _manager._player1 + " - " + _manager._player2;
        }
    }
}
