using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();

		lastChangeCounter = scoreManager.GetChangeCounter();
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreManager == null) {
			Debug.LogError("You forgot to add the score manager component to a game object!");
			return;
		}

		if(scoreManager.GetChangeCounter() == lastChangeCounter) {
			// No change since last update!
			return;
		}

		lastChangeCounter = scoreManager.GetChangeCounter();

		while(this.transform.childCount > 0) {
			Transform c = this.transform.GetChild(0);
			c.SetParent(null);  // Become Batman
			Destroy (c.gameObject);
		}

		string[] names = scoreManager.GetPlayerNames("username");
		
		foreach(string name in names) {
			GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
			go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = name;

            int starWarsScore = scoreManager.GetScore(name, "starWars");
            int snakeScore = scoreManager.GetScore(name, "snake");
            int notesScore = scoreManager.GetScore(name, "stickyNotes");
            var suma = starWarsScore + snakeScore + notesScore;

            //         go.transform.Find("Kills").GetComponent<Text>().text = scoreManager.GetScore(name, "kills").ToString();
            //go.transform.Find ("Deaths").GetComponent<Text>().text = scoreManager.GetScore(name, "deaths").ToString();
            go.transform.Find ("Assists").GetComponent<Text>().text = scoreManager.GetScore(name, "assists").ToString();

            go.transform.Find("StarWars").GetComponent<Text>().text = starWarsScore.ToString();
            go.transform.Find("Snake").GetComponent<Text>().text = snakeScore.ToString();
            go.transform.Find("Notes").GetComponent<Text>().text = notesScore.ToString();
            go.transform.Find("Suma").GetComponent<Text>().text = suma.ToString();
        }
    }
}
