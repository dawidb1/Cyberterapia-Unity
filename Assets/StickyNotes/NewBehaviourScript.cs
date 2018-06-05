using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject Title;
    public GameObject TextBox;
    public GameObject TextBox1;
    public GameObject TextBox2;
    public GameObject LVL;
    public GameObject imgTxt;
    public GameObject imgTxt1;
    public GameObject imgTxt2;
    public GameObject imgLevel;
    public GameObject imgButton;

    public void ClickTheButton()
    {
        RandomLetters.doit = true;
        Title.SetActive(true);
        LVL.SetActive(true);
        TextBox.SetActive(true);
        TextBox1.SetActive(true);
        TextBox2.SetActive(true);
        imgLevel.SetActive(true);
        imgTxt.SetActive(true);
        imgTxt1.SetActive(true);
        imgTxt2.SetActive(true);
        imgButton.SetActive(false);

    }

}
