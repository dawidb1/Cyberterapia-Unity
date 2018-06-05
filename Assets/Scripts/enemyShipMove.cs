using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipMove : MonoBehaviour {


    
    
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        float speed = ShipSpawner.Speed;
        
        transform.Translate(new Vector3(0,1,0)*speed*Time.deltaTime);


	}
   
}
