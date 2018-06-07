using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroy : MonoBehaviour
{

    // Use this for initialization
    Vector3 originalPos;

    void Start()
    {
        originalPos = new Vector3(-4.57f,-1.9f,0);
        //alternatively, just: originalPos = gameObject.transform.position;

    }

    void OnTriggerEnter(Collider other)
    {
     //   GameObject ca1 = GameObject.Find("player").GetComponent<GameObject>();



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //  gameObject.transform.position = originalPos;
       // ca1.transform.position = originalPos;
     
    }
}