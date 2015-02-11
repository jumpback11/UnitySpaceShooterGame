using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject weaponTab, tankTab, utiliyTab;
	public Sprite activeImage, defaultImage, pointedImage, spriteComponent;
	
	// Use this for initialization
	void Start () {
		WeaponTab ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void WeaponTab()
	{
		weaponTab.GetComponent<Image> ().sprite = activeImage;
		tankTab.GetComponent<Image> ().sprite = defaultImage;
		utiliyTab.GetComponent<Image> ().sprite = defaultImage;
	}
	
	public void TankTab()
	{
		weaponTab.GetComponent<Image> ().sprite = defaultImage;
		tankTab.GetComponent<Image> ().sprite = activeImage;
		utiliyTab.GetComponent<Image> ().sprite = defaultImage;
	}
	
	public void UtiliyTab()
	{
		weaponTab.GetComponent<Image> ().sprite = defaultImage;
		tankTab.GetComponent<Image> ().sprite = defaultImage;
		utiliyTab.GetComponent<Image> ().sprite = activeImage;
	}

}
