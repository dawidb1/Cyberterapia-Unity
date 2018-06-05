using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour {

    public void RestartGame()                                                                   //Rozpoczęcie gry od nowa.
    {
        RandomLetters.howmany = 0;
        RandomLetters.RESULT = 0;
        RandomLetters.LVL = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Wczytanie sceny.
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
