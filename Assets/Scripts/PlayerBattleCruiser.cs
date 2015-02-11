using UnityEngine;
using System.Collections;

public class PlayerBattleCruiser : MonoBehaviour {

	PlayerShip player;
	Shooter shooter;
	float damage, nextRegen;
	GameObject member1, member2, member3, member4;
	float hp1, hp2, hp3, hp4;
	GameController gameController;
	
	// Use this for initialization
	void Start () {
		player = transform.GetComponentInParent <PlayerShip> ();
		StatCalculations ();
		player.hp = player.maxHp;
		player.range = 60;
		player.size = 4;
		//player.LaunchDrone (5);
		
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
			player.maxHp = 1700;
			break;
		case 2: 
			player.maxHp = 2050;
			break;
		case 3:
			player.maxHp = 2825;
			break;
		case 4:
			player.maxHp = 4375;
			break;
		case 5:
			player.maxHp = 6250;
			break;
		default:
			player.maxHp = 1250;
			break;
		}
	}
	
	void Speed(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.speed = 105;
			break;
		case 2: 
			player.speed = 123;
			break;
		case 3:
			player.speed = 140;
			break;
		case 4:
			player.speed = 158;
			break;
		case 5:
			player.speed = 175;
			break;
		default:
			player.speed = 88;
			break;
		}
	}
	
	void Gun(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.gun = 15.87f *  player.damBonus;
			break;
		case 2: 
			player.gun = 19.14f *  player.damBonus;
			break;
		case 3:
			player.gun = 19.58f *  player.damBonus;
			break;
		case 4:
			player.gun = 40.85f *  player.damBonus;
			break;
		case 5:
			player.gun = 58.35f *  player.damBonus;
			break;
		default:
			player.gun = 11.67f *  player.damBonus;
			break;
		}
	}
	
	void ResistBonus(int lvl)
	{
		switch (lvl) {
		case 1: 
			player.resist = 1.437f;
			break;
		case 2: 
			player.resist = 1.51f;
			break;
		case 3:
			player.resist = 1.583f;
			break;
		case 4:
			player.resist = 1.656f;
			break;
		case 5:
			player.resist = 1.729f;
			break;
		default:
			player.resist = 1.364f;
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
