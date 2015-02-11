using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIToggleShip : MonoBehaviour {

	public GameObject[] shipGroup;
	Image ship1, ship2, ship3, ship4, ship5;
	public GameObject rookie, frigate, destroyer, cruiser, battleCruiser;
	public PlayerController player;
	public GameObject selectedShip;
	public GameObject defaultShip;
	bool frigateBought, destroyerBought, cruiserBought, bcBought;
	Color active, inactive;
	public GameObject rookieShip, frigateShip, destroyerShip, cruiserShip, battleCruiserShip;
	public GameObject rookieToggle, frigateToggle, destroyerToggle, cruiserToggle, battleCruiserToggle;
	
	// Use this for initialization
	void Start () {		
		active = Color.white;
		inactive = Color.grey;
		
		ship1 = shipGroup [0].GetComponent<Image> ();
		ship2 = shipGroup [1].GetComponent<Image> ();
		ship3 = shipGroup [2].GetComponent<Image> ();
		ship4 = shipGroup [3].GetComponent<Image> ();
		ship5 = shipGroup [4].GetComponent<Image> ();
		
		ship1.color = active;
		ship2.color = inactive;
		ship3.color = inactive;
		ship4.color = inactive;
		ship5.color = inactive;

		rookieShip.SetActive (true);
		frigateShip.SetActive (false);
		destroyerShip.SetActive (false);
		cruiserShip.SetActive (false);
		battleCruiserShip.SetActive (false);

		rookieToggle.SetActive (true);
		frigateToggle.SetActive (false);
		destroyerToggle.SetActive (false);
		cruiserToggle.SetActive (false);
		battleCruiserToggle.SetActive (false);

		selectedShip = rookie;

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Rookie()
	{
		ship1.color = active;
		ship2.color = inactive;
		ship3.color = inactive;
		ship4.color = inactive;
		ship5.color = inactive;
		
		rookieShip.SetActive (true);
		frigateShip.SetActive (false);
		destroyerShip.SetActive (false);
		cruiserShip.SetActive (false);
		battleCruiserShip.SetActive (false);
		
		rookieToggle.SetActive (true);
		frigateToggle.SetActive (false);
		destroyerToggle.SetActive (false);
		cruiserToggle.SetActive (false);
		battleCruiserToggle.SetActive (false);
		selectedShip = rookie;
	}

	public void Frigate()
	{
		ship1.color = inactive;
		ship2.color = active;
		ship3.color = inactive;
		ship4.color = inactive;
		ship5.color = inactive;
		
		rookieShip.SetActive (false);
		frigateShip.SetActive (true);
		destroyerShip.SetActive (false);
		cruiserShip.SetActive (false);
		battleCruiserShip.SetActive (false);
		
		rookieToggle.SetActive (false);
		frigateToggle.SetActive (true);
		destroyerToggle.SetActive (false);
		cruiserToggle.SetActive (false);
		battleCruiserToggle.SetActive (false);

		selectedShip = frigate;

		if (!frigateBought){
			GameController.money -= 565000;
			frigateBought = true;
		}
	}

	public void Destroyer()
	{
		ship1.color = inactive;
		ship2.color = inactive;
		ship3.color = active;
		ship4.color = inactive;
		ship5.color = inactive;
		
		rookieShip.SetActive (false);
		frigateShip.SetActive (false);
		destroyerShip.SetActive (true);
		cruiserShip.SetActive (false);
		battleCruiserShip.SetActive (false);
		
		rookieToggle.SetActive (false);
		frigateToggle.SetActive (false);
		destroyerToggle.SetActive (true);
		cruiserToggle.SetActive (false);
		battleCruiserToggle.SetActive (false);

		selectedShip = destroyer;

		if (!destroyerBought){
			GameController.money -= 1410000;
			destroyerBought = true;
		}
	}

	public void Cruiser()
	{
		ship1.color = inactive;
		ship2.color = inactive;
		ship3.color = inactive;
		ship4.color = active;
		ship5.color = inactive;
		
		rookieShip.SetActive (false);
		frigateShip.SetActive (false);
		destroyerShip.SetActive (false);
		cruiserShip.SetActive (true);
		battleCruiserShip.SetActive (false);
		
		rookieToggle.SetActive (false);
		frigateToggle.SetActive (false);
		destroyerToggle.SetActive (false);
		cruiserToggle.SetActive (true);
		battleCruiserToggle.SetActive (false);

		selectedShip = cruiser;

		if (!cruiserBought){
			GameController.money -= 10290000;
			cruiserBought = true;
		}
	}

	public void BattleCruiser()
	{
		ship1.color = inactive;
		ship2.color = inactive;
		ship3.color = inactive;
		ship4.color = inactive;
		ship5.color = active;
		
		rookieShip.SetActive (false);
		frigateShip.SetActive (false);
		destroyerShip.SetActive (false);
		cruiserShip.SetActive (false);
		battleCruiserShip.SetActive (true);
		
		rookieToggle.SetActive (false);
		frigateToggle.SetActive (false);
		destroyerToggle.SetActive (false);
		cruiserToggle.SetActive (false);
		battleCruiserToggle.SetActive (true);

		selectedShip = battleCruiser;

		if (!bcBought){
			GameController.money -= 45100000;
			bcBought = true;
		}
	}
}
