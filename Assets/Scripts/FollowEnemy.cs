using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour {

	private Vector3 enemyPos, playerPos;
	float angle;
	EnemyShip enemy;
	
	void Start()
	{

	}
	
	void Update ()
	{
		if (GameObject.FindWithTag ("Enemy") != null)
			enemy = GameObject.FindWithTag ("Enemy").GetComponent <EnemyShip> ();
		
		enemyPos = enemy.transform.position;
		playerPos = transform.position;
		enemyPos.x = enemyPos.x - playerPos.x;
		enemyPos.y = enemyPos.y - playerPos.y;
		angle = Mathf.Atan2(enemyPos.y, enemyPos.x) * Mathf.Rad2Deg + 270;
		transform.rotation = Quaternion.Euler(0, 0, angle);
		
		
	
	}	

}

