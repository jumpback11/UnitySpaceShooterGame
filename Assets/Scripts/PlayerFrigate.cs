using UnityEngine;
using System.Collections;

public class PlayerFrigate : MonoBehaviour {


	PlayerShip player;
	Shooter shooter;
	float damage;

	// Use this for initialization
	void Start () {
		player = transform.GetComponentInParent <PlayerShip> ();
		StatCalculations ();
		player.hp = player.maxHp;
		player.range = 30;
		player.size = 1;

	}
	
	// Update is called once per frame
	void Update () {
		StatCalculations ();
		/*if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
			player.isBoosting = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){
			player.isBoosting = false;
		}*/
	}

	void StatCalculations ()
	{
		MaxHp (player.hpLvl);
		Gun (player.weaponLvl);
		Speed (player.speedLvl);
		//Regen (player.regenLvl);
		DamBonus (player.damBonusLvl);
		ResistBonus (player.resistLvl);
	}

	void Regen(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.regen = 18;
			break;
		case 2: 
			player.regen = 20;
			break;
		case 3:
			player.regen = 22;
			break;
		case 4:
			player.regen = 24;
			break;
		case 5:
			player.regen = 26;
			break;
		default:
			player.regen = 0;
			break;
		}
	}

	void MaxHp(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.maxHp = 205;
			break;
		case 2: 
			player.maxHp = 250;
			break;
		case 3:
			player.maxHp = 335;
			break;
		case 4:
			player.maxHp = 525;
			break;
		case 5:
			player.maxHp = 750;
			break;
		default:
			player.maxHp = 150;
			break;
		}
	}

	void Speed(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.speed = 225;
			break;
		case 2: 
			player.speed = 275;
			break;
		case 3:
			player.speed = 325;
			break;
		case 4:
			player.speed = 375;
			break;
		case 5:
			player.speed = 425;
			break;
		default:
			player.speed = 175;
			break;
		}
	}

	void Gun(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.gun = 4.18f *  player.damBonus;
			break;
		case 2: 
			player.gun = 5.01f *  player.damBonus;
			break;
		case 3:
			player.gun = 6.68f *  player.damBonus;
			break;
		case 4:
			player.gun = 10.02f *  player.damBonus;
			break;
		case 5:
			player.gun = 16.67f *  player.damBonus;
			break;
		default:
			player.gun = 3.34f *  player.damBonus;
			break;
		}
	}

	void ResistBonus(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.resist = 1.276f;
			break;
		case 2: 
			player.resist = 1.322f;
			break;
		case 3:
			player.resist = 1.368f;
			break;
		case 4:
			player.resist = 1.414f;
			break;
		case 5:
			player.resist = 1.46f;
			break;
		default:
			player.resist = 1.23f;
			break;
		}
	}

	void DamBonus(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.damBonus = 1.1f;
			break;
		case 2: 
			player.damBonus = 1.2f;
			break;
		case 3: 
			player.damBonus = 1.3f;
			break;
		case 4: 
			player.damBonus = 1.4f;
			break;
		case 5: 
			player.damBonus = 1.5f;
			break;
		default:
			player.damBonus = 1;
			break;
		}
	}

}
