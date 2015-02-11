using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	Vector3 mousePos, cameraPos, playerPos, movePosition;
	float angle;

	void Update ()
	{
		mousePos = Input.mousePosition;
		cameraPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - cameraPos.x;
		mousePos.y = mousePos.y - cameraPos.y;
		angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg + 270;
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);
	}
}
