using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour {

public GameObject inventory;
bool active = false;


	// Use this for initialization
	void Start () {
		 Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.I))
		{
				active = !active;

		}
		inventory.SetActive(active);
		 Cursor.visible = active;
		//Cursor.visible= active;


  
	}

}
