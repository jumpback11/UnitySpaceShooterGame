using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	float xMin, xMax, yMin, yMax;
	EnemyShip ship;
	Transform player;
	public bool isShooting;

	// Use this for initialization
	void Start () {
		xMin = GameController.xMin;
		xMax = GameController.xMax;
		yMin = GameController.yMin;
		yMax = GameController.yMax;
		if (transform.GetComponent <EnemyShip> () != null)
			ship = transform.GetComponent <EnemyShip> ();
		if(GameObject.FindWithTag ("Player") != null)
			player = (GameObject.FindWithTag ("Player")).transform;
		if (transform != null)
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, RandomDirection());
	
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) 
			isShooting = true;
		else
			isShooting = false;
		
		if (player == null && !GameController.gameOver && GameObject.FindWithTag("Player") != null)
			player = (GameObject.FindWithTag ("Player")).transform;
	}

	void FixedUpdate ()
	{
		Move ();	
		
		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, xMin, xMax), 
			 Mathf.Clamp(transform.position.y, yMin, yMax), 0.0f);
	}
	
	float RandomDirection()
	{
		return Random.Range (0, 360);
	}
	
	void Move ()
	{
		transform.Translate (Vector2.up * Time.deltaTime * (ship.speed / 20), Space.Self);

		if (transform.position.x >= xMax || transform.position.x <= xMin || 
		    transform.position.y >= yMax || transform.position.y <= yMin){
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, RandomDirection());

		}
	}
}
