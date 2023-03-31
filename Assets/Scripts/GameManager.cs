using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int _player1;
    public int _player2;

    void Start()
    {
        DontDestroyOnLoad(this);
        ResetScores();
    }

    public void ResetScores()
    {
        _player1 = 0;
        _player2 = 0;
    }

}
