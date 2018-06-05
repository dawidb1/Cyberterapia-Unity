using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVLUP : MonoBehaviour {

    public InputField input;
    public GameObject Count;
    public GameObject Score;
    public GameObject Image;
    public GameObject ButtonContinue;
    public GameObject Input;
    public GameObject ButtonExit;                                                                  //Prycisk powrotu do pokoju (sceny głównej projektu - DO ZAPROGRAMOWANIA)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public GameObject ButtonRetry;

    string answer;

    public void ClickTheButton()
    {                                                                           //Ustawienia ekranu wynikowego
        answer = input.text;
        string a = Count.GetComponent<Text>().text;
        if (int.Parse(answer) == int.Parse(a) && (RandomLetters.LVL <6))
        {
            RandomLetters.RESULT += 1;                                          //Główny wynik gry - wartość zwracana do całego projektu - RETURN DO ZAPROGRAMOWANIA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            RandomLetters.LVL += 1;
            RandomLetters.doit = true;
            input.text = "";
            Count.GetComponent<Text>().text = "0";
            RandomLetters.howmany = 0;
        }
        else
        {
            if (RandomLetters.LVL == 6)
            {
                RandomLetters.RESULT++;
            }
            Input.SetActive(false);
            ButtonContinue.SetActive(false);
            ButtonRetry.SetActive(true);
            ButtonExit.SetActive(true);
            Image.SetActive(true);
            Score.SetActive(true);
            if(RandomLetters.LVL ==6)
                Score.GetComponent<Text>().text = "GRATULACJE! Uzyskałeś maksymalną ilość punktów!";
            else
                Score.GetComponent<Text>().text = " Uzyskałeś " + RandomLetters.RESULT + " na 6 możliwych punktów!";
            // WYNIKI W RESULT 
            //return RESULT
        }
    }
}
