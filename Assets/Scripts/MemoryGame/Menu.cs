using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

	public void Play()
	{
        Debug.Log("Play clicked");
		SceneManager.LoadScene("Scene_001");
	}
	public void End()
	{
        Debug.Log("End clicked");
        SceneManager.LoadScene((int)SceneEnum.ROOM);
    }
    public void Exit()
    {
        Debug.Log("Exit?? in Menu clicked");
        SceneManager.LoadScene((int)SceneEnum.ROOM);
    }
}
