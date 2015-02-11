using UnityEngine;
using System.Collections;

public class PlayerMissileMovement : MonoBehaviour {

	private Vector3 missilePos, enemyPos;
	float angle;
	GameObject enemy;
	int randomEnemy;

	void Start()
	{
		if (Shooter.enemies.Count > 0)
			randomEnemy = Random.Range (0, Shooter.enemies.Count - 1);
		enemy = Shooter.enemies [randomEnemy] as GameObject;


	}
	
	void Update ()
	{
		if (enemy != null){
			enemyPos = enemy.transform.position;
			missilePos = transform.position;
			enemyPos.x = enemyPos.x - missilePos.x;
			enemyPos.y = enemyPos.y - missilePos.y;
			angle = Mathf.Atan2(enemyPos.y, enemyPos.x) * Mathf.Rad2Deg + 270;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
		}
	}
}
