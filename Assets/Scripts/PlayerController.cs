using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	PlayerShip player;
	int speed;
	float xMin, xMax, yMin, yMax;
	Slider healthBar;
	Text name;
	Transform canvas;
	public GameObject shipObject;
	GameObject ship;
	GameController gameController;
	bool isBoosting;

	// Use this for initialization
	void Start () {
		player = transform.GetComponent<PlayerShip> ();
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();

		isBoosting = false;
		if(shipObject != null){
			GameController.players.Add (gameObject);
			GameController.party.Add (gameObject);
			ship = Instantiate (shipObject, transform.position, transform.rotation) as GameObject;
			ship.transform.parent = transform;
			healthBar = transform.GetComponentInChildren <Slider> ();
			name = transform.GetComponentInChildren <Text> ();
			name.text = shipObject.name;
			player.healthBar = healthBar;
			canvas = transform.GetChild(0);
			canvas.parent = null;
			speed = player.speed;
		}else{
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		xMin = GameController.xMin;
		xMax = GameController.xMax;
		yMin = GameController.yMin;
		yMax = GameController.yMax;

	}

	void FixedUpdate ()
	{

		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, xMin, xMax), 
			 Mathf.Clamp(transform.position.y, yMin, yMax), 0.0f);
	}

	void OnDestroy()
	{
		GameController.party.Remove (player);
		GameController.players.Remove (gameObject);
		gameController.PlayerCountCheck();
		Shooter.enemies.Clear ();
	}
}
