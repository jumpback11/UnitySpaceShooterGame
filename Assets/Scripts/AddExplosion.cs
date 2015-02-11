using UnityEngine;
using System.Collections;

public class AddExplosion : MonoBehaviour {

	public GameObject explosion, explosionAudio;

	void Update()
	{
		if(!gameObject.activeSelf){
			Instantiate(explosionAudio, transform.position, transform.rotation);
			Instantiate(explosion, transform.position, transform.rotation);
		}
	}
}
