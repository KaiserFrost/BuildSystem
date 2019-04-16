using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	// Use this for initialization~

	public GameObject prefabObj;
	GameObject currentObj;
	Vector3 positionobj;
	bool place = false;
	Placeable placeable;
	bool refresh = false;
	Quaternion currentrotation;
	
	void Start() {

}
	
	// Update is called once per frame
	void Update () 
	{
		
		 if(Input.GetButtonDown("Pick") || refresh == true)
		 {
			
			 	if(currentObj != null)
				 {
					 Destroy(currentObj);
				 }

				 else
				 {
					 
					 currentObj = Instantiate(prefabObj,Vector3.zero,currentrotation);
					 currentObj.layer = LayerMask.NameToLayer ("Ignore Raycast");
					 refresh = false;
				 }
		 }
		 else if(Input.GetButtonDown("Pick") && refresh == true)
		 {
			 refresh = false;
			 if(currentObj != null)
				 {
					 Destroy(currentObj);
				 }
		 }
		 
		 

		 if(currentObj != null)
		 {
				 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        		 RaycastHit hit;
       			 if (Physics.Raycast(ray, out hit))
       			 {
         			   currentObj.transform.position = new Vector3((float)Math.Round(hit.point.x,0),(float)Math.Round(hit.point.y,0),(float)Math.Round(hit.point.z,0));
         	
				 }

					if(Input.GetKeyDown(KeyCode.Y))
						{
							currentObj.transform.Rotate(0,90,0);
							currentrotation = currentObj.transform.rotation;
						}
						
				 
     		
       			 if (Input.GetMouseButtonDown(0) && currentObj.GetComponent<Placeable>().isBuildable == true)
        		 {
					 	
						currentObj.layer = LayerMask.NameToLayer ("Default");
            			Instantiate(prefabObj,currentObj.transform.position,currentObj.transform.rotation);
						refresh = true;
       			 }

		 }

	}
}

