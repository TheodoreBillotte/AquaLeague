using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	private bool isFinished = false;
	private Text text;
	[SerializeField] private float gameDuration;
	public string sceneToLoad;
	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
    {
	    if (!isFinished)
	    {
		    if (gameDuration > 0)
		    {
			    gameDuration -= Time.deltaTime;
		    }
		    else
		    {
			    isFinished = true;
			    gameDuration = 0;
			    SceneManager.LoadScene(sceneToLoad);
		    }
		    text.text = String.Format("{0:00}:{1:00}", (int) gameDuration / 60, (int) gameDuration % 60);
	    }
    }
}
