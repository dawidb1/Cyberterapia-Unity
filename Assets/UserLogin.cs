using Assets;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour {

    public GameObject Username;
    public GameObject EnterBtn;
    static string PATH = "results.txt";

    string username;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        username = Username.GetComponent<InputField>().text;
     
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (username != "")
            {
                EnterRoom();
            }
        }
        
	}

    public void EnterRoom()
    {
        UserSingleton.Instance.Username = username;
        FindCsvEntity(username);

        SceneManager.LoadScene((int)SceneEnum.ROOM);
    }

    void FindCsvEntity(string username)
    {
        StreamReader reader = new StreamReader(PATH);
        List<string> linesList = new List<string>();
        List<CsvModel> entityModelList = new List<CsvModel>();

        while (!reader.EndOfStream)
        {
            var text = reader.ReadLine();
            linesList.Add(text);
        }

        if (linesList != null)
        {
            foreach (var line in linesList)
            {
                string[] entityArray = line.Split(';');
                if (entityArray.Length >= 5)
                {
                    entityModelList.Add(new CsvModel(entityArray));
                }
                else
                {
                    entityModelList.Add(new CsvModel());
                }
            }
        }
        int i = 0;

        UserSingleton.Instance.Reset();
        UserSingleton.Instance.Username = username;
        foreach (var user in entityModelList)
        {
            if (user.Name == username)
            {
                UserSingleton.Instance.MemoryBest = int.Parse(user.MemoryScore);
                UserSingleton.Instance.NotesBest = int.Parse(user.NotesScore);
                UserSingleton.Instance.SnakeBest = int.Parse(user.SnakeScore);
                UserSingleton.Instance.StarWarsBest = int.Parse(user.StarWarsScore);
                UserSingleton.Instance.LineInCsv = i;
            }
            i++;
        }
    }
}
