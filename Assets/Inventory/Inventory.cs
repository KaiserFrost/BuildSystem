using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Transform parent;
	public GameObject itemSlotPrefab;
	public List<ItemSlot> itemSlots = new List<ItemSlot>();
	public int maxStackableItems;
	public int maxSlots;
	

	// Update is called once per frame
	void Update () {


	CheckifSlotisEmpty();
 	
	 RaycastHit hit;

if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,30))
{
	Item ite = hit.transform.GetComponent<ItemRef>().item;
	if(ite != null)
	{
		Debug.Log(ite.name);
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(!isFull())
			{
				if(IsonInventory(ite))
				{
					Stackit(ite);
				}
				else
				{
			
					NewSlotForItem(ite);
		
				}
				Destroy(hit.transform.gameObject);
			}
		}
	}
	
}
		
		
	}


void CheckifSlotisEmpty()
{
	for(int i = 0; i < itemSlots.Count; i++)
		{
			if(itemSlots[i] == null)
			{
					itemSlots.Remove(itemSlots[i]);
			}
		
		}
}
	bool IsonInventory(Item item)
	{
		for(int i = 0; i < itemSlots.Count; i++)
		{
			if(item.Id == itemSlots[i].item.Id)
			{
					if(itemSlots[i].amount +1 <= maxStackableItems)
					return true;
			}
		
		}
			return false;

		
	}

	bool isFull()
	{

			if(itemSlots.Count <= maxSlots)
				return false;

	
			else return true;
	}

	void Stackit(Item item)
	{
		for(int i = 0; i < itemSlots.Count; i++)
		{
			if(item.Id == itemSlots[i].item.Id)
			{
					itemSlots[i].amount++;
					
			}
		
		}
		
	}

	void NewSlotForItem(Item ite)
	{
	    GameObject  gameObject= Instantiate(itemSlotPrefab,parent);
		gameObject.GetComponent<ItemSlot>().item = ite;
		gameObject.GetComponent<ItemSlot>().amount = 1;
		itemSlots.Add(gameObject.GetComponent<ItemSlot>());

	}

	
}
