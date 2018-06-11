using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {
    GameObject starWars;
    GameObject memoryCards;
    GameObject stickyNotes;
    GameObject snakeHandler;
    GameObject scoreBoard;
    GameObject usernameHandler;
    GameObject exit;

    // Use this for initialization
    void Start () {
        starWars = GameObject.Find("StarWarsHandler");
        memoryCards = GameObject.Find("CardHandler");
        stickyNotes = GameObject.Find("StickyNotes");
        snakeHandler = GameObject.Find("SnakeHandler");
        scoreBoard = GameObject.Find("ScoreBoard");
        usernameHandler = GameObject.Find("UsernameHandler");
        exit = GameObject.Find("wyjscie");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                if (starWars.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.STAR_WARS);
                }
                else if (memoryCards.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.MEMORY_GAME);
                }
                else if (stickyNotes.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.STICKY_NOTES);
                }
                else if (snakeHandler.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.SNAKE);
                }
                
                else if (scoreBoard.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.SCORE_BOARD);
                }
                else if (usernameHandler.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene((int)SceneEnum.USER_LOGIN);
                }
                else if (exit.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    Application.Quit();
                    Debug.Log("You sdafdsafdsafd the " + hit.transform.name);
                }
            }
        }

       /*IENumerable ScaleMe(Transform objTr)
        {
            objTr.localScale *= 1.2f;
            yield return new WaitForSeconds(0.5f);
            objTr.localScale /= 1.2f;
        }*/
    }

    public void GoToRoom()
    {
        SceneManager.LoadScene((int)SceneEnum.ROOM);
    }
}
