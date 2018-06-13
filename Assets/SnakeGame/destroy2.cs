using Assets;
using Assets.Scripts.Csv;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class destroy2 : MonoBehaviour
{
    public static double EndScore;
    public Button Score;

    // Use this for initialization
    void Start()
    {
        Score.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Exit?? in End clicked");
        //SceneManager.LoadScene(0);
        Application.Quit();

        PlayerPrefs.SetFloat("Highscore", MyTimer.czas);

        float time = PlayerPrefs.GetFloat("Highscore");

        float score = 0;

        if (time <= 25)
        {
            score = 100;
        }
        if (time > 25 && time <= 115)
        {
           // score = Math.Abs((time - 25) - 100);
            score = 100 - time;
        }
        if (time > 115)
        {
            score = 10;
        }


        EndScore = Math.Floor(score);


        //string ScoreString =score.ToString();

        //EndScore = double.Parse(ScoreString);

        //EndScore = Math.Floor(EndScore);

        
        if (IsBestRecord())
        {
            UpdateSingleton();
            CsvSnapshot.AddRecordToCsv();
        }

        Score.GetComponentInChildren<Text>().text = string.Format("Wynik: {0}", EndScore);
        Score.gameObject.SetActive(true);

    }

    public void GoToRoom()
    {
        //System.Threading.Thread.Sleep(1000);
        SceneManager.LoadScene((int)SceneEnum.ROOM);
        //Destroy(other.gameObject);
        Destroy(GameObject.Find("Canvas"));
    }

    void UpdateSingleton()
    {
        var record = UserSingleton.Instance.SnakeBest;
        if (EndScore > record)
        {
            UserSingleton.Instance.SnakeBest = (int)EndScore;
        }
    }

    bool IsBestRecord()
    {
        var best = UserSingleton.Instance.SnakeBest;
        if (EndScore > best)
        {
            return true;
        }
        return false;
    }
}
