using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Next : MonoBehaviour {

    // Use this for initialization

    private Vector3 bedroomView = new Vector3(-21.73f, -0.8f, -10);
     Camera mainCam;
    void Start () {
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
  

    void OnTriggerEnter(Collider other)
	{

        //Destroy(other.gameObject);
	  //  Camera cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
	    //Camera cam2 = GameObject.Find("Camera").GetComponent<Camera>();
	   // mainCam = GameObject.Find("Main Camera").transform.position;
        //  cam1.enabled = false;
        //   cam2.enabled = true;
	    mainCam.transform.position = bedroomView;
	    // cam1.gameObject.SetActive(false);
	    //  cam2.gameObject.SetActive(true);
	    //Application.LoadLevel ("SecondScene");
	}
}
