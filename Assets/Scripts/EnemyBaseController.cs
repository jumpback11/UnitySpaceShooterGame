using UnityEngine;
using System.Collections;

public class EnemyBaseController : MonoBehaviour {

	Collider2D baseCollider;
	public bool base2, base3;
	public GameObject weapons, weapons2, shield;
	public static GameObject baseObject;
	EnemyShip ship;
	public static bool active;
	EnemyMissileMovement emMovement;
	Vector3 initialScale;

	// Use this for initialization
	void Start () {
		if (transform.GetComponent <PolygonCollider2D> () != null)						
			baseCollider = transform.GetComponent <PolygonCollider2D> ();

		baseObject = gameObject;
		baseCollider.enabled = false;
		weapons.SetActive (false);
		weapons2.SetActive (false);
		shield.SetActive (false);
		EnemyBaseController.active = false;

		if(transform.GetComponent<EnemyMissileMovement> () != null){
			emMovement = transform.GetComponent<EnemyMissileMovement> ();
			emMovement.enabled = false;
		}

		if (transform.GetComponent <EnemyShip> () != null)
			ship = transform.GetComponent <EnemyShip> ();

		initialScale = new Vector3 (8, 8, 8);

	}
	
	// Update is called once per frame
	void Update () {
		if(transform != null)
			transform.Rotate (Vector3.forward, Time.deltaTime * 2);

		if (ship != null && ship.hpPercentage <= 0.25f && !base3){
			weapons2.SetActive (true);
			shield.SetActive (true);
			ship.resist = 1.5f;
		}
		if (EnemyBaseController.active && base2) {
			emMovement.enabled = true;
		}

		if (EnemyBaseController.active) {
			baseCollider.enabled = true;
			weapons.SetActive (true);
			transform.Translate(-Vector2.right * Time.deltaTime * (ship.speed / 20), Space.World);
			if (transform.position.x <= 0)
				transform.position = new Vector3(0, 0, 0);
			StartCoroutine(ship.ScaleTo(4, initialScale, new Vector3 (18, 18, 18)));
			if(base3)
				transform.Rotate (Vector3.forward, Time.deltaTime * 24);
		}

		if (transform.position.x == 0 && base3){
			ship.speed = 0;
			weapons2.SetActive (true);
			shield.SetActive (true);
			ship.resist = 1.5f;
		}
	}

	public static void ActivateBase()
	{
		GameController.enemies.Add (baseObject);
		EnemyBaseController.active = true;
	}

	void OnDestroy()
	{
		GameController gameController;
		if (GameObject.FindWithTag ("GameController") != null){
			gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
			GameController.enemies.Remove (gameObject);
			gameController.EnemyCountCheck ();
		}
	}
}
