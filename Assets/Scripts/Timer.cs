using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	private float timer = 0;
	private bool isFinished = false;
	private Text text;
	[SerializeField] private float gameDuration;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
    {
	    if (!isFinished)
	    {
		    if (timer < gameDuration)
		    {
			    timer += Time.deltaTime;
		    }
		    else
		    {
			    isFinished = true;
			    timer = gameDuration;
			    Application.Quit();
		    }
		    text.text = String.Format("{0:00}:{1:00}", (int) timer / 60, (int) timer % 60);
	    }
    }
}
