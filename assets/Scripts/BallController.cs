using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	[SerializeField]
	private float speed = 0;

	Rigidbody rb;
	bool Started = false;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!Started) {
			if (leftClick()) {
				startBall ();
				Started = true;
			}
		}

		if (leftClick()) {
			switchDirection ();
		}
	}

	//All custom funtion here
	void startBall() {
		rb.velocity = new Vector3 (speed, 0, 0);
	}

	void switchDirection(){
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	bool leftClick(){
		if (Input.GetMouseButtonDown (0)) {
			return true;
		} else {
			return false;
		}
	}
}
