using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goals : MonoBehaviour
{
    public int goals = 0;
    public GameObject player;
    
    private GameObject _game;
    private Text _score;
    private Goals _goalLeft;
    private Goals _goalRight;

    void Start()
    {
        _game = GameObject.Find("GAME");
        _score = GameObject.Find("Scores").GetComponent<Text>();
        _goalLeft = GameObject.Find("GOAL L").GetComponent<Goals>();
        _goalRight = GameObject.Find("GOAL R").GetComponent<Goals>();
    }

    private void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.name == "Ball")
        {
            ball.transform.position = new Vector3(0, 0, 0);
            player.transform.position = new Vector3(-15.5F, -4F, 0);

            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            goals++;
            
            _score.text = _goalRight.goals + " - " + _goalLeft.goals;
        }
    }
}
