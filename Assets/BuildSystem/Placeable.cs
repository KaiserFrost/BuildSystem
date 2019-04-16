using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour {

	//[HideInInspector]
	public List<Collider> colliders = new List<Collider>();

	public bool isBuildable;
	public Material green;
	public Material red;
	
	void Start () {
		
		//original = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.layer != 0)
		ChangeColor();

		
	}

	private void OnTriggerEnter(Collider other) {
		
			if(other.tag != "Terrain")
			colliders.Add(other);
		
	}

	private void OnTriggerExit(Collider other) {
		
		if(other)
		{
			colliders.Remove(other);
		}
	}

	public void ChangeColor()
	{
		if(colliders.Count == 0)
		{
			isBuildable = true;
		}
		else 
		{
			
			isBuildable = false;
		}

		if(isBuildable)
		{
			foreach (Transform child in this.transform)
			{
				child.GetComponent<Renderer>().material = green;
			}
		}

		else
		{
			foreach (Transform child in this.transform)
			{
				child.GetComponent<Renderer>().material = red;
			}
		}
	}
}
	
