using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using Assets;

public class UIMenager : MonoBehaviour {
    //Brajan&Patryk
    public static bool gameOver = false;

    public Text scoreText;
    public Text TimeText;
    static int score;
    static float startTime;
    public static float StartTime;
    public static int Score
    {
        get { return score; }
        set { score = value; }
    }
    string EndTime;
    string EndScore;

    public Button[] buttons;

    public List<string> Results;
  

    // Use this for initialization
    public void Start()
    {
        Debug.Log("Start");
        score = 0;
        TimeText.text = "00:00";
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (gameOver==false)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString("f0");
            string seconds = (t % 60).ToString("f2");
            TimeText.text ="Time: "+ minutes + ":" + seconds;
            EndTime= "Time: "+minutes + ":" + seconds;
            scoreText.text = "Score: " + score;
            EndScore= "Score: " + score;
        }
        else
        {
         
            scoreText.text = EndScore;
            TimeText.text = EndTime;
            ButtonActivating();

            if (EndScore != string.Empty && EndTime != string.Empty)
            {
                if (Results.Count == 0)
                {
                    string result = EndScore + ";" + EndTime + ";";
                    Results.Add(result);

                }
                else
                {
                    if ((EndScore + ";" + EndTime + ";") != Results[Results.Count - 1])
                    {
                        string result = EndScore + ";" + EndTime + ";";
                        Results.Add(result);
                    }
                }
            }
        }
    }

    public void Replay()
    {
        if (IsBestRecord())
        {
            UpdateSingleton();
            CsvModel.AddRecordToCsv();
        }

        Debug.Log("Replay");
        SceneManager.LoadScene(SceneEnum.STAR_WARS.GetHashCode());
        
        gameOver = false;
        ShipSpawner.Speed = -5f;
    }
    public void Exit()
    {
        if (IsBestRecord())
        {
            UpdateSingleton();
            CsvModel.AddRecordToCsv();
        }

        Debug.Log("dupa");
        SceneManager.LoadScene(SceneEnum.ROOM.GetHashCode(),LoadSceneMode.Single);
    }
    void ButtonActivating()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    void UpdateSingleton()
    {
        var record = UserSingleton.Instance.StarWarsBest;
        if (score > record)
        {
            UserSingleton.Instance.StarWarsBest = score;
        }
    }

    bool IsBestRecord()
    {
        var best = UserSingleton.Instance.StarWarsBest;
        if (score > best)
        {
            return true;
        }
        return false;
    }
   
}
