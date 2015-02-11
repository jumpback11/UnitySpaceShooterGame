using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableByPrice : MonoBehaviour {

	UIToggleGroup toggleGroup;
	int cost;
	Button increaseButton;

	// Use this for initialization
	void Start () {
		toggleGroup = transform.GetComponent <UIToggleGroup> ();
		increaseButton = transform.GetChild (6).GetComponent <Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		cost = toggleGroup.cost;
		if (cost > GameController.money)
			increaseButton.interactable = false;
		else
			increaseButton.interactable = true;
	}
}
