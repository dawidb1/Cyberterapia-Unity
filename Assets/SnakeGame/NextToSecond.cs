using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextToSecond : MonoBehaviour
{
    private Vector3 scena3 = new Vector3(25.15f, -0.9f, -10);
    Camera mainCam;
    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        mainCam.transform.position = scena3;
    }

}

