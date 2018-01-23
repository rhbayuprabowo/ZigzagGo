using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	[SerializeField]
	private float speed = 0;

	public GameObject particle;

	Rigidbody rb;
	bool Started;
	bool GameOver;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		Started = false;
		GameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Started) {
			if (leftClick()) {
				startBall ();
				Started = true;
			}
		}

		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			GameOver = true;
			rb.velocity =new Vector3(0, -25f, 0);
			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
		}

		if (leftClick() && !GameOver) {
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

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Diamond") {
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

			Destroy (col.gameObject);
			Destroy (part, 1f);
		}
	}
}
