using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {
    public GameObject mis;
    GameObject memoryCards;
    GameObject stickyNotes;
    GameObject snakeHandler;
    GameObject scoreBoard;

    // Use this for initialization
    void Start () {
        memoryCards = GameObject.Find("CardHandler");
        stickyNotes = GameObject.Find("StickyNotes");
        snakeHandler = GameObject.Find("SnakeHandler");
        scoreBoard = GameObject.Find("ScoreBoard");
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
                if (mis.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene(1);
                }
                else if (memoryCards.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene(2);
                }
                else if (stickyNotes.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene(5);
                }
                else if (snakeHandler.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene(6);
                }
                else if (scoreBoard.Equals(hit.transform.gameObject))
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    SceneManager.LoadScene(7);
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
        SceneManager.LoadScene(0);
    }
}
