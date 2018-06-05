using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLetters : MonoBehaviour {

    //Globalne
    public static int RESULT = 0;
    public static int LVL = 1;
    public static char letter;
    public static bool doit = false;
    public static int howmany = 0;
    //Obiekty
    public GameObject textBox;
    public GameObject textBox1;
    public GameObject textBox2;
    public GameObject countBox;
    public GameObject title;
    public GameObject Level;
    public GameObject Input;
    public GameObject Button;
    public GameObject Button2;
    //Lokalne/Sterujące
    System.Random rnd = new System.Random();
    List<char> alfabet = new List<char>();
    bool ready = false;
    string alfa = "ABCDEFGHIJKLMNOPRSTUWXYZ";
    int i = 0;
    bool way = false;
    char a;


    // Update is called once per frame
    void Update()
    {
        if (doit == true)
        {
            //Wyświetlenie głównych napisów
            Level.GetComponent<Text>().text = "Poziom: " + LVL.ToString();
            textBox.SetActive(true);
            textBox1.SetActive(true);
            textBox2.SetActive(true);
            Input.SetActive(false);
            Button.SetActive(false);
            Button2.SetActive(false);
            //Sterownik budujący alfabet i wybierający literę
            if (ready == false)
            {
                //Utworzenie Alfabetu
                alfabethmaker();
                //Wybranie szukanej litery
                letter = a = SelectLetter();
                title.GetComponent<Text>().text = "Policz ile razy pojawi się litera: " + letter.ToString();
                //Dodanie 5 dodatkowych powtórzeń litery do alfabetów w celu podniesienia frekwencji
                for (int n = 0; n < 5; n++)
                {
                    alfabet.Add(letter);
                }
            }
            //Sterownik głównej funkcjonalności programu
            else
            {
                //Sterownik Update na wyświetlanie liter.
                if (way == true)
                {
                    if (i != 0)
                        System.Threading.Thread.Sleep(200);         //Chwila przerwy na zatrzymanie pustego pola (efekt mrugnięcia podczas zmiany)
                    switch (LVL)
                    {
                                                                    //Wybór poziomu trudności
                        case 1:
                        case 4:
                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox, a.ToString());
                            break;
                        case 2:
                        case 5:
                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox, a.ToString());

                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox1, a.ToString());
                            break;
                        case 3:
                        case 6:
                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox, a.ToString());

                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox1, a.ToString());

                            a = SelectLetter();
                            compare(a);
                            WriteText(textBox2, a.ToString());
                            break;
                    }
                    way = false;                                    //Zmiana sterownika
                }
                //Sterownik wyświetlajacy puste pola (charakterystyczne mrugnięcie podczas zmiany liter)
                else
                {
                    i++;
                    if ((i == 0))                                   //Stoper przed rozpoczęcię gry na zapoznanie z treścią
                        System.Threading.Thread.Sleep(3000);
                    else if (LVL < 4)
                        System.Threading.Thread.Sleep(2000);        //Stoper decydujący o szybkości zmiany liter lvl 1-3 wolniej niż 4-6
                    else
                        System.Threading.Thread.Sleep(1000);
                    WriteText(textBox, "");                         //Puste pola - mrugnięcie
                    WriteText(textBox1, "");
                    WriteText(textBox2, "");
                    way = true;
                    if ((i > 5))                                    //Licznik zmian na level
                    {
                        way = false;
                        doit = false;
                        ready = false;
                        i = 0;
                        LVLUP();                                                    
                    }
                }
            }
        }
    }
    public void alfabethmaker()                     //Tworzy Alfabet z ciągu znaków
    {
        foreach (char c in alfa)
        {
            alfabet.Add(c);
        }
        ready = true;
    }



    public void compare(char a)                 // porównuje literę wylosowaną z literą szukaną i zlicza wynik
    {
        if (a == letter)
        {
            howmany += 1;
            countBox.GetComponent<Text>().text = howmany.ToString();
        }
    }

    public char SelectLetter()                  //Losowanie Litery z zwiększonym zakresem losowania - na każdą literę przypada 10 liczb
    {
        char lett = alfabet[int.Parse((Mathf.Floor((rnd.Next(0, (alfabet.Count * 10) - 1)) / 10)).ToString())];
        return lett;
    }

    public void WriteText(GameObject GO, string text)               //Zmiana tekstu w obiektach 
    {
        GO.GetComponent<Text>().text = text;
    }

    public void LVLUP()                                             //Ustawienie pod ekran wynikowy
    {
        title.GetComponent<Text>().text = "Ile razy wyświetliła się litera: " + letter.ToString() + "?";
        textBox.SetActive(false);
        textBox1.SetActive(false);
        textBox2.SetActive(false);
        Button.SetActive(false);
        Input.SetActive(true);
        Button2.SetActive(true);
    }
}
