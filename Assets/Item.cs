using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject 
{

public enum Tipo
 {
    Material, 
    Placeble, 
    Usable
 };
	
	
	public int Id;
	public string name;
	public Sprite icon;
	public GameObject obj;

	[HideInInspector]
	public Tipo tipo;
	[HideInInspector]
	public int healthGain;
	[HideInInspector]
	public int foodGain;

	void Start() 
	{
		
	}
}


[CustomEditor(typeof(Item))]
public class Item_Editor : Editor 
{
	public override void OnInspectorGUI() 
	{

		

		Item script = (Item)target;

		script.tipo = (Item.Tipo)EditorGUILayout.EnumPopup("Tipo",script.tipo);
		
	switch(script.tipo)
	{
		case Item.Tipo.Material:
		//script.name = EditorGUILayout.TextField("Name", script.name);
		break;

		case Item.Tipo.Placeble:

		break;

		case Item.Tipo.Usable:
		script.healthGain = EditorGUILayout.IntField("Health", script.healthGain);
		script.foodGain = EditorGUILayout.IntField("Food", script.foodGain);
		
		break;

	}
		
		DrawDefaultInspector(); 
	}
}



