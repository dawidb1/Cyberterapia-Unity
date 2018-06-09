using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSingleton : MonoBehaviour {

	public static UserSingleton Instance { get; private set; }

    public string Username;
    public int SnakeBest;
    public int NotesBest;
    public int StarWarsBest;
    public int MemoryBest;
    public int LineInCsv;

    private void Awake()
    {
        if (Instance ==  null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Reset()
    {
        UserSingleton.Instance.Username = "noname";
        UserSingleton.Instance.LineInCsv = 999;
        UserSingleton.Instance.MemoryBest = 0;
        UserSingleton.Instance.NotesBest = 0;
        UserSingleton.Instance.SnakeBest = 0;
        UserSingleton.Instance.StarWarsBest = 0;
    }

}
