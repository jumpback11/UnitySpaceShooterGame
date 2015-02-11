using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockByCost : MonoBehaviour {

	public int cost;
	GameObject lockImage;
	Button shipToggle;

	// Use this for initialization
	void Start () {
		lockImage = gameObject;
		shipToggle = transform.parent.GetComponent <Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.money >= cost){
			lockImage.SetActive(false);
			shipToggle.interactable = true;
		}else{
			lockImage.SetActive(true);
			shipToggle.interactable = false;
		}
	}
}
