using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float hp, resist, regen, gun, range, nextRegen, bounty, hpPercentage, slowSpeed;
	public int size, level, speed, maxHp, regSpeed;
	int regenCount;	
	public bool isLvl2;
	public GameObject explosion, explosionAudio;
	public GameController gameController;
	SpriteRenderer sprite;
	Gradient gradient = new Gradient();	

	// Use this for initialization
	void Start () {
		if ( GameObject.FindWithTag ("GameController") != null)
			gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();

		if (resist == 0)
			resist = 1;

		hp = maxHp;

		if (transform.GetComponent<EnemyBaseController>() == null)
			GameController.enemies.Add (gameObject);

		if ( transform.GetComponent <SpriteRenderer> () != null)
			sprite = transform.GetComponent <SpriteRenderer> ();

		DeadRed ();

		if (transform.GetComponent<EnemyBaseController>() == null)
			StartCoroutine (ScaleTo (2, new Vector3 (0.1f, 0.1f, 0.1f), transform.localScale));

		if (transform.GetComponent<EnemyBaseController>() != null)
			transform.localScale = new Vector3 (8, 8, 8);
	}
	
	// Update is called once per frame
	void Update () {

		hpPercentage = hp / maxHp;
		sprite.color = gradient.Evaluate(hpPercentage);

		if ( hp >=  maxHp)
			hp = maxHp;
		
		if (hp <  maxHp && Time.time > nextRegen && level > 3){
			hp +=  regen;
			nextRegen = Time.time + 1;
		}

		if ( hp <= 0){
			Instantiate(explosionAudio, transform.position, transform.rotation);
			Instantiate(explosion, transform.position, transform.rotation);
			GameController.money += (long) bounty;
			Destroy (gameObject);
		}

	}

	void DeadRed()
	{

		GradientColorKey[] color;
		GradientAlphaKey[] alpha;

		color = new GradientColorKey[2];
		alpha = new GradientAlphaKey[2];
		color [0].color = Color.red;
		color [0].time = 0;
		color [1].color = Color.white;
		color [1].time = 1;
		alpha [0].alpha = 255;
		alpha [0].time = 0;
		alpha [1].alpha = 255;
		alpha [1].time = 1;
		gradient.SetKeys (color, alpha);

	}

	void OnDestroy()
	{
		if (GameController.enemies != null && GameController.enemies.Contains(gameObject)) 
			GameController.enemies.Remove(gameObject);
		if (isLvl2 && transform.GetComponent <EnemyBaseController> () == null)
			EnemyBaseController.ActivateBase ();
		if (gameController != null)
			gameController.EnemyCountCheck ();
		if(Shooter.enemies != null && Shooter.enemies.Contains(gameObject))
			Shooter.enemies.Remove (gameObject);
	}

	public IEnumerator ScaleTo(float duration, Vector3 initialScale, Vector3 scale) {
		
		float timeThrough = 0.0f;
		
		while (transform.localScale.x <= scale.x){
			timeThrough += Time.deltaTime;
			Vector3 target = Vector3.Lerp(initialScale, scale, timeThrough / duration);
			transform.localScale = target;
			yield return null;
		}
	}

}
