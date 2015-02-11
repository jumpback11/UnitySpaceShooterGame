using UnityEngine;
using System.Collections;

public class EnemyMissileMovement : MonoBehaviour {

	private Vector3 missilePos, playerPos;
	float angle;
	Transform player;

	void Start()
	{
		if (GameObject.FindWithTag ("Player") != null)
			player = (GameObject.FindWithTag ("Player")).transform;

	}
	
	void Update ()
	{
		if (GameObject.FindWithTag ("Player") != null)
			player = (GameObject.FindWithTag ("Player")).transform;
		if (player != null){
			playerPos = player.position;
			missilePos = transform.position;
			playerPos.x = playerPos.x - missilePos.x;
			playerPos.y = playerPos.y - missilePos.y;
			angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg + 270;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
		}
	}

}
