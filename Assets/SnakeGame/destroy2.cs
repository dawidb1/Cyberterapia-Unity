using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class destroy2 : MonoBehaviour
{
    public static double EndScore;

    // Use this for initialization
    void Start()
    {

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
            score = Math.Abs((time - 25) - 100);
        }
        if (time > 115)
        {
            score = 10;
        }

        string ScoreString =score.ToString();

        EndScore = double.Parse(ScoreString);

        EndScore = Math.Floor(EndScore);

       

        Destroy(other.gameObject);
        Destroy(GameObject.Find("Canvas"));
        
    }
}
