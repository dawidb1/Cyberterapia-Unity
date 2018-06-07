using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour {
	public static float czas = 0;
	public Text czas_txt;
	public GameObject plutno;
	// Use this for initialization

	void Awake () {
		//DontDestroyOnLoad (plutno);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		czas_txt= gameObject.GetComponent<Text>();
		czas += Time.deltaTime;
		czas_txt.text=string.Format("czas: {0}",czas);
	}
}
