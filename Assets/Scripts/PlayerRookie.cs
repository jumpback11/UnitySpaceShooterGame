using UnityEngine;
using System.Collections;

public class PlayerRookie : MonoBehaviour {

	PlayerShip player;
	Shooter shooter;
	float damage;
	GameObject drone;
	
	// Use this for initialization
	void Start () {
		player = transform.GetComponentInParent <PlayerShip> ();
		StatCalculations ();
		player.hp = player.maxHp;
		player.range = 20;
		player.size = 1;
		/*if (player.weaponLvl == 5)
			player.LaunchDrone (1);*/
		
	}
	
	// Update is called once per frame
	void Update () {
		StatCalculations ();
		
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
			player.maxHp = 68;
			break;
		case 2: 
			player.maxHp = 82;
			break;
		case 3:
			player.maxHp = 113;
			break;
		case 4:
			player.maxHp = 175;
			break;
		case 5:
			player.maxHp = 250;
			break;
		default:
			player.maxHp = 50;
			break;
		}
	}
	
	void Speed(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.speed = 300;
			break;
		case 2: 
			player.speed = 350;
			break;
		case 3:
			player.speed = 400;
			break;
		case 4:
			player.speed = 450;
			break;
		case 5:
			player.speed = 500;
			break;
		default:
			player.speed = 250;
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
