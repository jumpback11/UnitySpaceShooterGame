using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private float xMin, xMax, yMin, yMax, x, y, speed;
	private bool mouseDown;
	private Camera main;
	private int orthoSize;
	private Vector3 currMousePos, prevMousePos, position;
	// Use this for initialization
	void Start () {
		main = camera.GetComponent<Camera>();
		orthoSize = (int)main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		currMousePos = Input.mousePosition;

		if (Input.GetAxis("Mouse ScrollWheel") > 0 && orthoSize > 1){
			main.orthographicSize -= 1;
			orthoSize = (int)main.orthographicSize;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && orthoSize < 15){
			main.orthographicSize += 1;
			orthoSize = (int)main.orthographicSize;
		}

		Boundary (orthoSize);

		speed = orthoSize * 0.0075f;

		if (Input.GetMouseButtonDown(0))
			mouseDown = true;

		if (Input.GetMouseButtonUp(0))
			mouseDown = false;

	}

	void FixedUpdate()
	{
		position = transform.position;
		if (mouseDown){
			prevMousePos = Input.mousePosition;
			x = currMousePos.x - prevMousePos.x;
			y = currMousePos.y - prevMousePos.y;
			position.x += (x * speed);
			position.y += (y * speed);
			transform.position = position;
			
		}
		transform.position = new Vector3 
			(Mathf.Clamp(transform.position.x, xMin, xMax), 
			 Mathf.Clamp(transform.position.y, yMin, yMax), -20);
	}

	void Boundary(int orthoSize)
	{
		switch(orthoSize){
		case 1:
			xMin = -30.6f;
			xMax = 30.6f;
			yMax = 17;
			yMin = -17;
			break;
		case 2:
			xMin = -29.3f;
			xMax = 29.3f;
			yMax = 16;
			yMin = -16;
			break;
		case 3:
			xMin = -28;
			xMax = 28;
			yMax = 15;
			yMin = -15;
			break;
		case 4:
			xMin = -26.6f;
			xMax = 26.6f;
			yMax = 14;
			yMin = -14;
			break;
		case 5:
			xMin = -25.3f;
			xMax = 25.3f;
			yMax = 13;
			yMin = -13;
			break;
		case 6:
			xMin = -24;
			xMax = 24;
			yMax = 12;
			yMin = -12;
			break;
		case 7:
			xMin = -22.7f;
			xMax = 22.7f;
			yMax = 11;
			yMin = -11;
			break;
		case 8:
			xMin = -21.4f;
			xMax = 21.4f;
			yMax = 10;
			yMin = -10;
			break;
		case 9:
			xMin = -20.1f;
			xMax = 20.1f;
			yMax = 9.1f;
			yMin = -9.1f;
			break;
		case 10:
			xMin = -18.7f;
			xMax = 18.7f;
			yMax = 8.1f;
			yMin = -8.1f;
			break;
		case 11:
			xMin = -17.4f;
			xMax = 17.4f;
			yMax = 7.1f;
			yMin = -7.1f;
			break;
		case 12:
			xMin = -16.1f;
			xMax = 16.1f;
			yMax = 6.1f;
			yMin = -6.1f;
			break;
		case 13:
			xMin = -14.8f;
			xMax = 14.8f;
			yMax = 5.1f;
			yMin = -5.1f;
			break;
		case 14:
			xMin = -13.4f;
			xMax = 13.4f;
			yMax = 4.1f;
			yMin = -4.1f;
			break;
		default:
			xMin = -12.1f;
			xMax = 12.1f;
			yMax = 3.1f;
			yMin = -3.1f;
			break;
		}
	}
}
