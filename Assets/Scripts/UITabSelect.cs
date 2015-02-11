using UnityEngine;
using System.Collections;

public class UITabSelect : MonoBehaviour {

	public GameObject[] tabs;
	GameObject tab1, tab2, tab3, tab4;

	// Use this for initialization
	void Start () {
		tab1 = tabs [0];
		tab2 = tabs [1];
		tab3 = tabs [2];
		tab4 = tabs [3];
		tab1.SetActive (true);
		tab2.SetActive (false);
		tab3.SetActive (false);
		tab4.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Tab1()
	{
		tab1.SetActive (true);
		tab2.SetActive (false);
		tab3.SetActive (false);
		tab4.SetActive (false);
	}

	public void Tab2()
	{
		tab1.SetActive (false);
		tab2.SetActive (true);
		tab3.SetActive (false);
		tab4.SetActive (false);
	}

	public void Tab3()
	{
		tab1.SetActive (false);
		tab2.SetActive (false);
		tab3.SetActive (true);
		tab4.SetActive (false);
	}

	public void Tab4()
	{
		tab1.SetActive (false);
		tab2.SetActive (false);
		tab3.SetActive (false);
		tab4.SetActive (true);
	}
}
