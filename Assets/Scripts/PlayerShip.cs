using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	public bool isShooting, isBoosting;
	public float hp, resist, regen, gun, range, regenBonus, resistBonus, damBonus, speedBonus, hpPercent; 
	float nextRegen;
	public int size, level, speed, maxHp;
	public Slider healthBar;	 
	public int hpLvl, weaponLvl, speedLvl, regenLvl, damBonusLvl, resistLvl;
	public GameObject explosion, explosionAudio, drone, droneAudio;

	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		regen = (float) (maxHp / 35);

		if ( hp >=  maxHp)
			hp =  maxHp;

		hpPercent = hp / maxHp;
		
		if (hp <  maxHp && Time.time > nextRegen && !isShooting){
			hp +=  regen;
			nextRegen = Time.time + 1;
		}

		if ( hp <= 0){
			Instantiate(explosionAudio, transform.position, transform.rotation);
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (gameObject);

		}

		if (healthBar != null){
			healthBar.maxValue = maxHp;
			healthBar.value = hp;
		}
	}

	public void LaunchDrone(int amount)
	{
		for (int i = 0; i < amount; i++){
			Instantiate (drone, transform.position, transform.rotation);
			Instantiate (droneAudio, transform.position, transform.rotation);
		}
	}
}
