using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Csv;
using System.Collections.Generic;
using System.Linq;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();

		lastChangeCounter = scoreManager.GetChangeCounter();
        scoreManager.Reset();
        FillFromCsv();
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

        FillFromCsv();
    }

    public void FillFromCsv()
    {
        Debug.Log("Fill from csv");
        List<CsvModel> allEntries = CsvSnapshot.GetRecordList();
        var orderBySuma = allEntries.OrderByDescending(x => int.Parse(x.Suma));   //todo fuj

        foreach (var user in orderBySuma)
        {
            GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Username").GetComponent<Text>().text = user.Name;

            go.transform.Find("Memory").GetComponent<Text>().text = user.MemoryScore;
            go.transform.Find("StarWars").GetComponent<Text>().text = user.StarWarsScore;
            go.transform.Find("Snake").GetComponent<Text>().text = user.SnakeScore;
            go.transform.Find("Notes").GetComponent<Text>().text = user.NotesScore;
            go.transform.Find("Suma").GetComponent<Text>().text = user.Suma;
        }
    }
}
