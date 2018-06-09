using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : SceneController {
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
        
        SceneManager.LoadScene(0,LoadSceneMode.Single);
	}
}
