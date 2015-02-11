using UnityEngine;
using System.Collections;

public class DroneMove : MonoBehaviour {

	private Vector3 enemyPos, playerPos;
	float angle, lastAngle, xMin, xMax, yMin, yMax;
	int speed;
	EnemyShip enemy;
	PlayerShip player;
	
	void Start ()
	{
		player = transform.GetComponentInParent<PlayerShip> ();
	}
	
	void Update () {
		xMin = GameController.xMin;
		xMax = GameController.xMax;
		yMin = GameController.yMin;
		yMax = GameController.yMax;

		if (GameObject.FindWithTag ("Enemy") != null)
			enemy = GameObject.FindWithTag ("Enemy").GetComponent <EnemyShip> ();
		
		enemyPos = enemy.transform.position;
		playerPos = transform.position;
		enemyPos.x = enemyPos.x - playerPos.x;
		enemyPos.y = enemyPos.y - playerPos.y;
		angle = Mathf.Atan2(enemyPos.y, enemyPos.x) * Mathf.Rad2Deg + 270;
		transform.rotation = 
			Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * (4 / player.size));
		
		speed = player.speed;
		
	}
	
	void FixedUpdate ()
	{
		transform.Translate(Vector2.up * Time.deltaTime * (speed / 10), Space.Self);
		
		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, xMin, xMax), 
			 Mathf.Clamp(transform.position.y, yMin, yMax), 0.0f);
	}
	
	void Move ()
	{
		Vector2 movePosition = (Vector2) playerPos;
		transform.position = Vector2.SmoothDamp(playerPos, enemyPos,ref movePosition, 1, 10, Time.deltaTime);
	}
	
}
