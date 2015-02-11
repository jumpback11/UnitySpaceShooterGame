using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	float speed;
	float damage, range, resist, count;
	Shooter shooter;
	public GameObject audio;
	EnemyShip enemy;

	// Use this for initialization
	void Start () {
		shooter = transform.GetComponentInParent<Shooter> ();
		damage = shooter.damage;
		range = shooter.range;
		speed = shooter.speed;
		resist = 1;
		transform.parent.DetachChildren ();
		count = Time.time + (range * 4 / speed);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Time.time > count)
			Destroy (gameObject);
		
	}

	void FixedUpdate () 
	{
		Move ();

	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == ("Bullet") || target.tag == ("Player") || target.tag == ("Friendly"))
			return;

		if (target != null){
			enemy = target.GetComponent<EnemyShip>();
			resist = enemy.resist;
			if (resist == 0)
				resist = 1;
			damage = damage / resist;
			enemy.hp -= damage;
			Instantiate (audio, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	void Move()
	{		
		transform.Translate (Vector3.up * Time.deltaTime * speed, Space.Self);
	}
}
