using UnityEngine;
using System.Collections;

public class LVL1Boss : MonoBehaviour {

	EnemyShip ship;
	bool up, down;
	Transform player;
	public Transform turret1, turret2;
	FollowPlayer followPlayer;
	int increasedSpeed, speed;

	// Use this for initialization
	void Start () {
		if (GameObject.FindWithTag ("Player") != null)
			player = (GameObject.FindWithTag ("Player")).transform;
		if (transform.GetComponent <FollowPlayer> () != null){
			followPlayer = transform.GetComponent <FollowPlayer> ();
			followPlayer.enabled = false;
		}
		if (transform.GetComponent <EnemyShip> () != null){
			ship = transform.GetComponent <EnemyShip> ();
			increasedSpeed = Mathf.RoundToInt (ship.speed * 1.5f);
			speed = ship.speed;
		}
		up = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= GameController.yMax){
			up = false;
			down = true;
		}else if (transform.position.y <= GameController.yMin){
			up = true;
			down = false;
		}

		if (player != null && transform.position.x <= player.position.x || ship.hpPercentage <= 0.25f){
			turret1.GetComponent<EnemyMissileMovement>().enabled = true;
			turret2.GetComponent<EnemyMissileMovement>().enabled = true;
			turret1.GetComponent<EnemyShooter>().rof = 0.5f;
			turret2.GetComponent<EnemyShooter>().rof = 0.5f;
			ship.speed = increasedSpeed;
		}else{
			turret1.GetComponent<EnemyMissileMovement>().enabled = false;
			turret2.GetComponent<EnemyMissileMovement>().enabled = false;
			turret1.rotation = turret1.parent.rotation;
			turret2.rotation = turret2.parent.rotation;
			ship.speed = speed;
		}


		if ( followPlayer != null && ship.hpPercentage <= 0.5f){
			followPlayer.enabled = true;
			ship.speed = 400;
			turret1.GetComponent<EnemyMissileMovement>().enabled = true;
			turret2.GetComponent<EnemyMissileMovement>().enabled = true;
			turret1.GetComponent<EnemyShooter>().rof = 0.5f;
			turret2.GetComponent<EnemyShooter>().rof = 0.5f;
			this.enabled = false;
		}

	}

	void FixedUpdate()
	{
		if ( transform != null)
			Move ();
	}

	void Move()
	{
		if(up)
			transform.Translate (Vector2.up * Time.deltaTime * (ship.speed / 20), Space.World);
		if(down)
			transform.Translate (-Vector2.up * Time.deltaTime * (ship.speed / 20), Space.World);
	}
}
