using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour {

	public static long money;
	public static float xMin = -126, xMax = 126, yMin = -77, yMax = 77;
	Text moneyText, gameOverText;
	public int wave, startingWave, hp, weapon, speed, regen, damBonus, resist;
	float waveCount, waveTime;
	public Texture2D cursorTexture;
	public UIToggleGroup hp0, weapon0, speed0, regen0, damBonus0, resist0,
						 hp1, weapon1, speed1, regen1, damBonus1, resist1,
						 hp2, weapon2, speed2, regen2, damBonus2, resist2,
						 hp3, weapon3, speed3, regen3, damBonus3, resist3,
						 hp4, weapon4, speed4, regen4, damBonus4, resist4;
	public UIToggleShip ship;
	public GameObject[] enemyShips;
	public GameObject[] enemyBase;
	public static ArrayList players = new ArrayList();
	public static ArrayList enemies = new ArrayList();
	public static ArrayList party = new ArrayList();
	public static bool gameOver;
	bool waveOver, isActive, spawnPlayers, nextWave;
	GameObject uiWindowObject, enemy;
	public GameObject selectedShip;
	public GameObject player, rookie, frigate, destroyer, cruiser, battleCruiser;
	Vector3 playerStart = new Vector3(-63, 0, 0), enemyStart = new Vector3(63, 0, 0), enemyStart2 = new Vector3(63, 5, 0), mousePos;



	// Use this for initialization
	void Start () {
		moneyText = (GameObject.FindWithTag ("Score")).GetComponent<Text> ();
		gameOverText = (GameObject.FindWithTag ("GameOver")).GetComponent<Text> ();
		GameController.gameOver = false;
		gameOverText.text = "";
		spawnPlayers = false;
		if (GameObject.FindWithTag ("UI") != null){
			uiWindowObject = GameObject.FindWithTag ("UI");
			uiWindowObject.SetActive (false);
		}
		if (ship.selectedShip == null)
			selectedShip = rookie;
		else
			selectedShip = ship.selectedShip;

		spawnPlayers = true;
		startingWave = wave = 1;
		SpawnPlayers();

		CursorImage (cursorTexture);

	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = money.ToString();

		if(gameOver){
			OpenUI();
			DestroyEnemies();
		}

		if (Time.time > waveTime && nextWave)
			StartWave();
	}

	void CursorImage(Texture2D texture)
	{
		Vector2 cursorSpot;

		if (texture != null)
			cursorSpot = new Vector2 (16, 16);
		else
			cursorSpot = Vector2.zero;

		CursorMode cursorMode = CursorMode.Auto;
		Cursor.SetCursor (texture, cursorSpot, cursorMode);
	}

	void SpawnPlayers()
	{
		UpdateStats();
		Instantiate (player, playerStart, Quaternion.identity);	

		uiWindowObject.SetActive (false);
		CursorImage (cursorTexture);

		wave = startingWave;
		StartWave ();


	}

	void UpdateStats()
	{
		player.GetComponent<PlayerController> ().shipObject = selectedShip;
		player.GetComponent<PlayerShip> ().hpLvl = hp;
		player.GetComponent<PlayerShip> ().weaponLvl = weapon;
		player.GetComponent<PlayerShip> ().speedLvl = speed;
		//player.GetComponent<PlayerShip> ().regenLvl = regen0.setLevel;
		player.GetComponent<PlayerShip> ().damBonusLvl = damBonus;
		player.GetComponent<PlayerShip> ().resistLvl = resist;

	}

	void StartWave()
	{ 

		switch (wave) 
		{
		default:
			Enemy1 (RandomInt(1, wave), enemyStart);
			break;
		case 1:
			EnemyBase(1, enemyStart);
			Enemy1 (RandomInt(4, 6), enemyStart);			
			nextWave = true;
			break;
		case 2:
			Enemy1 (RandomInt(4, 6), enemyStart);
			break;
		case 3:
			Enemy1 (RandomInt(6, 8), enemyStart);
			break;
		case 4:
			Enemy1 (RandomInt(8, 10), enemyStart);
			break;
		case 5:
			Boss1 (1, enemyStart);
			nextWave = false;
			break;
		case 6:
			OpenUI();
			startingWave = 7;
			break;
		case 7:
			EnemyBase(2, enemyStart);
			Enemy2 (RandomInt(4, 6), enemyStart);			
			nextWave = true;
			break;
		case 8:
			Enemy2 (RandomInt(4, 6), enemyStart);
			break;
		case 9:
			Enemy2 (RandomInt(6, 8), enemyStart);
			break;
		case 10:
			Enemy2 (RandomInt(8, 10), enemyStart);
			break;
		case 11:
			Enemy2 (RandomInt(10, 12), enemyStart);
			break;
		case 12:
			Boss2 (1, enemyStart);
			nextWave = false;
			break;
		case 14:
			OpenUI();
			startingWave = 15;
			break;
		case 15:
			EnemyBase(3, enemyStart);
			Enemy3 (RandomInt(4, 6), enemyStart);
			nextWave = true;
			break;
		case 16:
			Enemy3 (RandomInt(4, 6), enemyStart);
			break;
		case 17:
			Enemy3 (RandomInt(6, 8), enemyStart);
			break;
		case 18:
			Enemy3 (RandomInt(8, 10), enemyStart);
			break;
		case 19:
			Enemy3 (RandomInt(10, 12), enemyStart);
			break;
		case 20:
			Boss3 (1, enemyStart);
			nextWave = false;
			break;
		case 21:
			OpenUI();
			startingWave = 22;
			break;		
		}

		wave += 1;
		waveTime = Time.time + 30;
	}

	int RandomInt(int min, int max)
	{
		return Random.Range (min, max);
	}

	public void PlayerCountCheck()
	{
		if (players.Count == 0){
			OpenUI();
			GameController.gameOver = true;
		}
	}

	public void EnemyCountCheck()
	{
		if (enemies.Count == 0 && !GameController.gameOver){
			StartWave();
		}
	}

	void DestroyEnemies()
	{
		if (GameObject.FindWithTag("Enemy") != null){
			enemy = GameObject.FindWithTag("Enemy");
			enemies.Remove(enemy);
			Destroy (enemy);
		}

		if (GameObject.FindWithTag("Scenery") != null){
			enemy = GameObject.FindWithTag("Scenery");
			Destroy (enemy);
		}
	}

	void OpenUI()
	{
		if(uiWindowObject != null)		
			uiWindowObject.SetActive (true);
		CursorImage(null);

		if (GameObject.FindWithTag("Player1") != null){
			enemy = GameObject.FindWithTag("Player1");
			players.Remove(enemy);
			Destroy (enemy);
		}

		GameController.enemies.Clear ();

		wave = 0;
	}

	public void UIAccept()
	{
		hp0.setLevel = hp0.selectedLevel;
		weapon0.setLevel = weapon0.selectedLevel;
		speed0.setLevel = speed0.selectedLevel;
		//regen0.setLevel = regen0.selectedLevel;
		damBonus0.setLevel = damBonus0.selectedLevel;
		resist0.setLevel = resist0.selectedLevel;

		hp1.setLevel = hp1.selectedLevel;
		weapon1.setLevel = weapon1.selectedLevel;
		speed1.setLevel = speed1.selectedLevel;
		//regen1.setLevel = regen1.selectedLevel;
		damBonus1.setLevel = damBonus1.selectedLevel;
		resist1.setLevel = resist1.selectedLevel;

		hp2.setLevel = hp2.selectedLevel;
		weapon2.setLevel = weapon2.selectedLevel;
		speed2.setLevel = speed2.selectedLevel;
		//regen2.setLevel = regen2.selectedLevel;
		damBonus2.setLevel = damBonus2.selectedLevel;
		resist2.setLevel = resist2.selectedLevel;

		hp3.setLevel = hp3.selectedLevel;
		weapon3.setLevel = weapon3.selectedLevel;
		speed3.setLevel = speed3.selectedLevel;
		//regen3.setLevel = regen3.selectedLevel;
		damBonus3.setLevel = damBonus3.selectedLevel;
		resist3.setLevel = resist3.selectedLevel;

		hp4.setLevel = hp4.selectedLevel;
		weapon4.setLevel = weapon4.selectedLevel;
		speed4.setLevel = speed4.selectedLevel;
		//regen3.setLevel = regen3.selectedLevel;
		damBonus4.setLevel = damBonus4.selectedLevel;
		resist4.setLevel = resist4.selectedLevel;

		selectedShip = ship.selectedShip;

		if(ship.selectedShip == rookie){
			hp = hp0.selectedLevel;
			weapon = weapon0.selectedLevel;
			speed = speed0.selectedLevel;
			//regen0.setLevel = regen0.selectedLevel;
			damBonus = damBonus0.selectedLevel;
			resist = resist0.selectedLevel;
		}

		if(ship.selectedShip == frigate){
			hp = hp1.selectedLevel;
			weapon = weapon1.selectedLevel;
			speed = speed1.selectedLevel;
			//regen0.setLevel = regen1.selectedLevel;
			damBonus = damBonus1.selectedLevel;
			resist = resist1.selectedLevel;
		}

		if(ship.selectedShip == destroyer){
			hp = hp2.selectedLevel;
			weapon = weapon2.selectedLevel;
			speed = speed2.selectedLevel;
			//regen0.setLevel = regen2.selectedLevel;
			damBonus = damBonus2.selectedLevel;
			resist = resist2.selectedLevel;
		}

		if(ship.selectedShip == cruiser){
			hp = hp3.selectedLevel;
			weapon = weapon3.selectedLevel;
			speed = speed3.selectedLevel;
			//regen0.setLevel = regen3.selectedLevel;
			damBonus = damBonus3.selectedLevel;
			resist = resist3.selectedLevel;
		}

		if(ship.selectedShip == battleCruiser){
			hp = hp4.selectedLevel;
			weapon = weapon4.selectedLevel;
			speed = speed4.selectedLevel;
			//regen0.setLevel = regen4.selectedLevel;
			damBonus = damBonus4.selectedLevel;
			resist = resist4.selectedLevel;
		}

		UIExit ();
	}

	public void UIExit()
	{
		GameController.gameOver = false;
		SpawnPlayers ();

	}

	void Enemy1(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [0], enemyStart, Quaternion.identity);
	}

	void Enemy2(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [1], enemyStart, Quaternion.identity);
	}

	void Enemy3(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [2], enemyStart, Quaternion.identity);
	}

	void Enemy4(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [3], enemyStart, Quaternion.identity);
	}

	void Enemy5(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [4], enemyStart, Quaternion.identity);
	}

	void Boss1(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [5], enemyStart, Quaternion.Euler (0, 0, 90));
	}
	
	void Boss2(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [6], enemyStart, Quaternion.identity);
	}
	
	void Boss3(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [7], enemyStart, Quaternion.Euler (0, 0, 90));
	}
	
	void Boss4(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [8], enemyStart, Quaternion.identity);
	}
	
	void Boss5(int amount, Vector3 enemyStart)
	{
		for (int i = 0; i < amount; i++)
			Instantiate (enemyShips [9], enemyStart, Quaternion.identity);
	}

	void EnemyBase(int index, Vector3 enemyStart)
	{
		Instantiate(enemyBase[index - 1], enemyStart, Quaternion.identity);
	}
}
