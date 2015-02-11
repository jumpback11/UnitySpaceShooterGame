using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIToggleGroup : MonoBehaviour {

	public GameObject[] toggleGroup;
	public int selectedLevel, setLevel;
	Image lvl1, lvl2, lvl3, lvl4, lvl5;
	public Button decrease, increase;
	Color active, inactive;
	public int cost, sellCost, price;

	// Use this for initialization
	void Start () {

		selectedLevel = 0;
		decrease = transform.GetChild (0).GetComponent<Button> ();
		active = Color.white;
		inactive = Color.grey;

		cost = price;

		lvl1 = toggleGroup [0].GetComponent<Image> ();
		lvl2 = toggleGroup [1].GetComponent<Image> ();
		lvl3 = toggleGroup [2].GetComponent<Image> ();
		lvl4 = toggleGroup [3].GetComponent<Image> ();
		lvl5 = toggleGroup [4].GetComponent<Image> ();

		lvl1.color = inactive;
		lvl2.color = inactive;
		lvl3.color = inactive;
		lvl4.color = inactive;
		lvl5.color = inactive;

	}
	
	// Update is called once per frame
	void Update () {
		Hilighted (selectedLevel);

		if (selectedLevel > setLevel)			
			decrease.interactable = true;
		else
			decrease.interactable = false;
	}

	void Hilighted(int index)
	{
		switch (index) {
		case 1: 
			lvl1.color = active;
			lvl2.color = inactive;
			lvl3.color = inactive;
			lvl4.color = inactive;
			lvl5.color = inactive;
			break;
		case 2: 
			lvl1.color = active;
			lvl2.color = active;
			lvl3.color = inactive;
			lvl4.color = inactive;
			lvl5.color = inactive;
			break;
		case 3:
			lvl1.color = active;
			lvl2.color = active;
			lvl3.color = active;
			lvl4.color = inactive;
			lvl5.color = inactive;
			break;
		case 4:
			lvl1.color = active;
			lvl2.color = active;
			lvl3.color = active;
			lvl4.color = active;
			lvl5.color = inactive;
			break;
		case 5:
			lvl1.color = active;
			lvl2.color = active;
			lvl3.color = active;
			lvl4.color = active;
			lvl5.color = active;
			break;
		default:
			lvl1.color = inactive;
			lvl2.color = inactive;
			lvl3.color = inactive;
			lvl4.color = inactive;
			lvl5.color = inactive;
			break;
			}
	}

	public void Increase()
	{
		if (selectedLevel < 5){
			selectedLevel += 1;
			GameController.money -= cost;
			cost = cost * 2;
		}
	}

	public void Decrease()
	{
		if (selectedLevel > setLevel){
			selectedLevel -= 1;
			sellCost = cost / 2;
			GameController.money += sellCost;
			cost = cost / 2;
		}
	}

}
