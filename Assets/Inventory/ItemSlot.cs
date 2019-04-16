using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

	public Item item;
	public Image image;
	public TextMeshProUGUI quantidade;
	public int amount = 0;
	GameObject player;
	public GameObject itemMenu;
	 Button use, destroy;
	 Transform parent;
	public Inventory inventory;
	

private void Start() {
	player = GameObject.FindGameObjectWithTag("Player");
	parent = GameObject.FindGameObjectWithTag("Canvas").transform;
	itemMenu = GameObject.FindGameObjectWithTag("MenuItem");
	
	
}
	private void Update() {
	
		if(item != null)
		{
			image.sprite = item.icon;
			quantidade.text = amount.ToString();
		}
		
	}

	public void CallItemMenu()
	{
			itemMenu.SetActive(true);
			
			itemMenu.transform.position = transform.position - new Vector3(0,itemMenu.GetComponent<RectTransform>().sizeDelta.y/3,0);
			itemMenu.transform.SetAsLastSibling();
			use = itemMenu.transform.Find("Use").GetComponent<Button>();
			destroy = itemMenu.transform.Find("Destroy").GetComponent<Button>();
			destroy.onClick.RemoveAllListeners();
			use.onClick.RemoveAllListeners();
			destroy.onClick.AddListener(Destroyit);
			use.onClick.AddListener(UseObject);
			
	}

	public void Destroyit()
	{
		Destroy(gameObject);
		
		Debug.Log("Destroy");
		itemMenu.SetActive(false);
	}

	public void UseObject()
	{
		switch(item.tipo)
	{
		case Item.Tipo.Material:
		Debug.Log("Material");
		break;

		case Item.Tipo.Placeble:
		Debug.Log("Placeble");
		break;

		case Item.Tipo.Usable:
		Debug.Log("Usable");
		break;

	}

	itemMenu.SetActive(false);
	}
}
