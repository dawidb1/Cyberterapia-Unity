using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreWindowManager : MonoBehaviour {

	public GameObject scoreBoard;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)) {
			scoreBoard.SetActive( !scoreBoard.activeSelf );
		}
	}

    public void BackToRoom()
    {
        SceneManager.LoadScene(0);
    }
}
