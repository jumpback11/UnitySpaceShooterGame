using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCruiser : MonoBehaviour {

	PlayerShip player;
	Shooter shooter;
	float damage;

	
	// Use this for initialization
	void Start () {
		player = transform.GetComponentInParent <PlayerShip> ();
		StatCalculations ();
		player.hp = player.maxHp;
		player.range = 50;
		player.size = 3;
		//player.LaunchDrone (2);
		
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
			player.maxHp = 1020;
			break;
		case 2: 
			player.maxHp = 1230;
			break;
		case 3:
			player.maxHp = 1695;
			break;
		case 4:
			player.maxHp = 2625;
			break;
		case 5:
			player.maxHp = 3750;
			break;
		default:
			player.maxHp = 750;
			break;
		}
	}
	
	void Speed(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.speed = 174;
			break;
		case 2: 
			player.speed = 203;
			break;
		case 3:
			player.speed = 232;
			break;
		case 4:
			player.speed = 261;
			break;
		case 5:
			player.speed = 290;
			break;
		default:
			player.speed = 145;
			break;
		}
	}
	
	void Gun(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.gun = 10.88f *  player.damBonus;
			break;
		case 2: 
			player.gun = 13.04f *  player.damBonus;
			break;
		case 3:
			player.gun = 18f *  player.damBonus;
			break;
		case 4:
			player.gun = 28f *  player.damBonus;
			break;
		case 5:
			player.gun = 40f *  player.damBonus;
			break;
		default:
			player.gun = 8f *  player.damBonus;
			break;
		}
	}
	
	void ResistBonus(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.resist = 1.343f;
			break;
		case 2: 
			player.resist = 1.40f;
			break;
		case 3:
			player.resist = 1.457f;
			break;
		case 4:
			player.resist = 1.514f;
			break;
		case 5:
			player.resist = 1.573f;
			break;
		default:
			player.resist = 1.286f;
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
