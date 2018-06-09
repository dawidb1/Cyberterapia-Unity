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
    static string PATH = "results.txt";

    // Use this for initialization
    public void Start ()
    {
        Debug.Log("Start");
        score = 0;
        TimeText.text = "00:00";
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
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
            WriteToSingleton();
            WriteToCsv();
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
            WriteToSingleton();
            WriteToCsv();
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
    void WriteToSingleton()
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
    void WriteToCsv()
    {
        var currentLine = UserSingleton.Instance.LineInCsv;
        if (currentLine == 999)
        {
            currentLine = File.ReadAllLines(PATH).Length;
            StreamWriter writer = new StreamWriter(PATH, append: true);
            var text = CsvEntity() + "\n";
            writer.WriteLine(text);
            writer.Close();
            UserSingleton.Instance.LineInCsv = currentLine;
        }
        else
        {
            string[] lines = System.IO.File.ReadAllLines(PATH);
            lines[currentLine] = CsvEntity();

            StreamWriter writer = new StreamWriter(PATH);
            foreach (var item in lines)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }
    }

    string CsvEntity()
    {
        int sum = UserSingleton.Instance.NotesBest
            + UserSingleton.Instance.StarWarsBest
             + UserSingleton.Instance.SnakeBest
              + UserSingleton.Instance.MemoryBest;

        char semicolon = ';';
        string entity = UserSingleton.Instance.Username + semicolon
              + UserSingleton.Instance.NotesBest + semicolon
              + UserSingleton.Instance.StarWarsBest + semicolon
              + UserSingleton.Instance.SnakeBest + semicolon
              + UserSingleton.Instance.MemoryBest + semicolon
              + sum;

        return entity;
    }

    //void FindCsvEntity()
    //{
    //    StreamReader reader = new StreamReader(PATH);
    //    List<string> linesList = new List<string>();
    //    List<CsvModel> entityModelList = new List<CsvModel>();

    //    while (!reader.EndOfStream)
    //    {
    //        if (reader.ReadLine() != "")
    //        {
    //            linesList.Add(reader.ReadLine());
    //        }
    //    }
    //    foreach (var line in linesList)
    //    {
    //        string[] entityArray = line.Split(';');
    //        entityModelList.Add(new CsvModel(entityArray));
    //    }

    //    foreach (var user in entityModelList)
    //    {
    //        if (user.Name == UserSingleton.Instance.name)
    //        {
    //            UserSingleton.Instance.MemoryBest = int.Parse(user.MemoryScore);
    //            UserSingleton.Instance.NotesBest = int.Parse(user.NotesScore);
    //            UserSingleton.Instance.SnakeBest = int.Parse(user.SnakeScore);
    //            UserSingleton.Instance.StarWarsBest = int.Parse(user.StarWarsScore);
    //        }
    //    }
    //}
}
