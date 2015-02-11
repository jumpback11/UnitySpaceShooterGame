using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	float damage, range, resist, count;
	float speed;
	EnemyShooter shooter;
	PlayerShip player;
	public GameObject audio;

	// Use this for initialization
	void Start () {
		shooter = transform.GetComponentInParent<EnemyShooter> ();
		damage = shooter.damage;
		range = shooter.range;
		speed = shooter.speed;
		transform.parent.DetachChildren ();
		count = Time.time + (range * 4 / speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > count)
			Destroy (gameObject);
	}

	void FixedUpdate () 
	{
		Move ();
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == ("Bullet") || target.tag == ("Enemy")){
			return;
		}

		player = target.gameObject.GetComponentInParent<PlayerShip>();
		resist = player.resist;
		damage = damage / resist;
		player.hp -= damage;
		Instantiate (audio, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	void Move()
	{		
		transform.Translate (Vector3.up * Time.deltaTime * speed, Space.Self);
	}
}
