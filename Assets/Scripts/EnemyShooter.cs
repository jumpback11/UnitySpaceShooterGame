using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

	public GameObject bullet, audio;
	public float damage, range, rof, speed;
	float nextFire, burstFire, burst;
	EnemyShip ship;
	GameObject shot;
	bool isShooting;
	public bool isBurst;
	
	// Use this for initialization
	void Start () {
		ship = transform.GetComponentInParent<EnemyShip> ();
		if (transform.GetComponentInParent<EnemyMove>() != null){
			EnemyMove controller;
			controller = transform.GetComponentInParent<EnemyMove> ();
			isShooting = controller.isShooting;
		} else if ( transform.GetComponentInParent<FollowPlayer>() != null){
			FollowPlayer controller;
			controller = transform.GetComponentInParent<FollowPlayer> ();
			isShooting = controller.isShooting;
		}
		if(damage == 0)
		damage = ship.gun;
		if(range == 0)
		range = ship.range;
		nextFire = Time.time + rof;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isBurst) {
			if (Time.time > nextFire){
				shot = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
				shot.transform.parent = transform;
				nextFire = Time.time + rof;
				Instantiate(audio, transform.position, transform.rotation);
			}
		}

		if (isBurst) {

			if (Time.time > burstFire){
				if (Time.time > nextFire && burst <= 10){
					shot = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
					shot.transform.parent = transform;
					nextFire = Time.time + rof;
					Instantiate(audio, transform.position, transform.rotation);
					burst += 1;
				}
				if (burst >= 10){
					burstFire = Time.time + 5;
					burst = 0;
				}
			}
		}
	}

}
