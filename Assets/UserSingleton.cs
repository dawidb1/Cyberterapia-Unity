using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSingleton : MonoBehaviour {

	public static UserSingleton Instance { get; private set; }

    public string Username;
    public int SnakeBest;
    public int NotesBest;
    public int StarWarsBest;

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

}
