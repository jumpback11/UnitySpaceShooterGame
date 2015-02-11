using UnityEngine;
using System.Collections;

public class Hexmap : MonoBehaviour {

	public GameObject hexagon, background;
	public int mapWidth, mapHeight;
	private float hexWidth = 1.52f; 
	private float hexHeight = 0.92f;

	// Use this for initialization
	void Start () {

		//Build hexmap

		HexMap1 ();

		HexMap2 ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HexMap1()
	{
		float x = ((mapWidth * -hexWidth) / 4);
		float y = ((mapHeight * -hexHeight) / 2);
		for (float i = x; i <= (mapWidth * hexWidth) / 4; i += hexWidth)
			for (float j = y; j <= (mapHeight * hexHeight) / 2; j += hexHeight) 
				Instantiate (hexagon, new Vector2 (i, j), transform.rotation);
	}

	void HexMap2() 
	{
		float x = ((mapWidth * -hexWidth) / 4) + (hexWidth / 2);
		float y = ((mapHeight * -hexHeight) / 2) + (hexHeight / 2);
		for (float i = x; i <= (mapWidth * hexWidth) / 4; i += hexWidth)
			for (float j = y; j <= (mapHeight * hexHeight) / 2; j += hexHeight) 
				Instantiate (hexagon, new Vector2 (i, j), transform.rotation);
	}
}
