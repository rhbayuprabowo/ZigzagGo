using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;

	public float lerpRate;

	public bool gameOver;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			Follow ();
		}
	}

	void Follow() {
		Vector3 CurrentPosition = transform.position;
		Vector3 TargetPosition = ball.transform.position - offset;
		CurrentPosition= Vector3.Lerp (CurrentPosition, TargetPosition, lerpRate * Time.deltaTime);
		transform.position = CurrentPosition;
	}
}
