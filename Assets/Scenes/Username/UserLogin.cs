using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour {

    public GameObject Username;
    public GameObject EnterBtn;

    string username;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        username = Username.GetComponent<InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (username != "")
            {
                EnterRoom();
            }
        }
	}

    void EnterRoom()
    {
        UserSingleton.Instance.Username = username;
        SceneManager.LoadScene(1);
    }
}
