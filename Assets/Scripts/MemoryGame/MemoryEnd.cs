﻿using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryEnd : SceneController {
    /*
	[SerializeField] public TextMesh scoreEnd; 

	public void Score()
	{
		scoreEnd.text = "Twój wynik: " + wynik;
	}
	*/
    public void Exit()
    {
        Debug.Log("Exit?? in End clicked");

        SceneManager.LoadScene((int)SceneEnum.ROOM, LoadSceneMode.Single);
    }
}