using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet, audio;
	public float damage, range, rof, speed;
	float nextFire;
	PlayerShip ship;
	GameObject shot, player;
	public static ArrayList enemies;

	// Use this for initialization
	void Start () {
		enemies = new ArrayList ();
		ship = transform.GetComponentInParent<PlayerShip> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (ship.isShooting && Time.time > nextFire && Shooter.enemies.Count > 0){
			if(damage == 0)
				damage = ship.gun;
			if(range == 0)
				range = ship.range;
			shot = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			shot.transform.parent = transform;
			nextFire = Time.time + rof;
			Instantiate(audio, transform.position, transform.rotation);
		}
		for (int i = 0; i < GameController.enemies.Count; i++)
			if (!Shooter.enemies.Contains (GameController.enemies [i]))
				Shooter.enemies.Remove (GameController.enemies [i]);
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "Enemy"){
			if(!Shooter.enemies.Contains(target.gameObject))
				Shooter.enemies.Add (target.gameObject);
		}else
			return;
	}

	void OnTriggerExit2D (Collider2D target)
	{
		if(Shooter.enemies.Contains(target.gameObject))
			Shooter.enemies.Remove (target.gameObject);

	}

}
