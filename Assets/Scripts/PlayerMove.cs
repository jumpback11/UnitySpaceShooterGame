using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Vector3 mousePos, cameraPos, playerPos, movePosition;
	float angle, lastAngle, xMin, xMax, yMin, yMax;
	int speed;
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

		mousePos = Input.mousePosition;
		cameraPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - cameraPos.x;
		mousePos.y = mousePos.y - cameraPos.y;
		angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 270;
		transform.rotation = 
			Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * (4 / player.size));
	
		speed = player.speed;

		if (Input.GetMouseButtonDown(0))
			player.isShooting = true;
		
		
		if (Input.GetMouseButtonUp (0))
			player.isShooting = false;
	
	}

	void FixedUpdate ()
	{
		if (player.isBoosting)
			transform.Translate(Vector2.up * Time.deltaTime * (speed * 2.575f / 20), Space.Self);

		if (!player.isBoosting)
			transform.Translate(Vector2.up * Time.deltaTime * (speed / 10), Space.Self);
				
		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, xMin, xMax), 
			 Mathf.Clamp(transform.position.y, yMin, yMax), 0.0f);
	}
	
	void Move ()
	{		
		Vector2 mousePos, cameraPos, playerPos, movePosition;

		mousePos = Input.mousePosition;
		cameraPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - cameraPos.x;
		mousePos.y = mousePos.y - cameraPos.y;
		playerPos = transform.position;
		movePosition = new Vector2 (mousePos.x, mousePos.y);
		transform.position = Vector2.SmoothDamp(playerPos, mousePos, ref playerPos, 1, 10, Time.deltaTime);
	}

}
