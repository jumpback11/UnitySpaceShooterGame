using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private Vector3 mouse_pos, object_pos;
	GameController gameController;
	float angle, range;
	Transform player;
	EnemyShip ship;
	public float x, y;
	public bool approach, isShooting;
	Vector3 up, down;

	void Start()
	{
		gameController = GameObject.FindWithTag ("GameController").GetComponent <GameController> ();
		if ((GameObject.FindWithTag ("Player")).transform != null)
			player = (GameObject.FindWithTag ("Player")).transform;
		ship = transform.GetComponent <EnemyShip> ();
		approach = true;
		up = new Vector3 (1, 1, 0);
		down = new Vector3 (1, 0, 0);
	}
	
	void Update ()
	{
		if (player != null){
			mouse_pos = player.position;
			object_pos = transform.position;
			x = mouse_pos.x - object_pos.x;
			y = mouse_pos.y - object_pos.y;
			angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 270;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
			isShooting = true;

			if (x >= (range * 4) || y >= (range * 4) || x <= -(range * 4) || y <= -(range * 4))
				approach = true;
			
			else if (x <= (range / 2) || y <= (range / 2) || x >= -(range / 2) || y >= -(range / 2))
				approach = false;
		} else
			isShooting = false;

		if (player == null && !GameController.gameOver && (GameObject.FindWithTag ("Player")) != null)
			player = (GameObject.FindWithTag ("Player")).transform;


		
	}

	void FixedUpdate ()
	{
		Move ();	

		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, GameController.xMin, GameController.xMax), 
			 Mathf.Clamp(transform.position.y, GameController.yMin, GameController.yMax), 0.0f);
	}

	void Move ()
	{
		if (approach){
			transform.Translate (up * Time.deltaTime * (ship.speed / 20), Space.Self);
		}
		if (!approach){
			transform.Translate (down * Time.deltaTime * (ship.speed / 20), Space.Self);
		}
	}
}
