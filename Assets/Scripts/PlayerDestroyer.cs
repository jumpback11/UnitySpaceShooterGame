using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

	PlayerShip player;
	Shooter shooter;
	float damage;
	
	// Use this for initialization
	void Start () {
		player = transform.GetComponentInParent <PlayerShip> ();
		StatCalculations ();
		player.hp = player.maxHp;
		player.range = 40;
		player.size = 2;
		
	}
	
	// Update is called once per frame
	void Update () {
		StatCalculations ();
		/*if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)){
			player.regen = 17.5f;
			player.speed = 0;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){
			player.regen = 3.74f;
			Speed (player.speedLvl);
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
			player.maxHp = 340;
			break;
		case 2: 
			player.maxHp = 410;
			break;
		case 3:
			player.maxHp = 565;
			break;
		case 4:
			player.maxHp = 875;
			break;
		case 5:
			player.maxHp = 1250;
			break;
		default:
			player.maxHp = 250;
			break;
		}
	}
	
	void Speed(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.speed = 180;
			break;
		case 2: 
			player.speed = 210;
			break;
		case 3:
			player.speed = 240;
			break;
		case 4:
			player.speed = 270;
			break;
		case 5:
			player.speed = 300;
			break;
		default:
			player.speed = 150;
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
			player.resist = 1.262f;
			break;
		case 2: 
			player.resist = 1.306f;
			break;
		case 3:
			player.resist = 1.350f;
			break;
		case 4:
			player.resist = 1.394f;
			break;
		case 5:
			player.resist = 1.438f;
			break;
		default:
			player.resist = 1.218f;
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
