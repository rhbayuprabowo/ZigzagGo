using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject Platform;

	public GameObject Diamond;

	Vector3 lastPost;
	float size;

	public bool GameOver;

	// Use this for initialization
	void Start () {
		lastPost = Platform.transform.position;
		size = Platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) {
			SpawnPlatforms ();
		}

		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameOver) {
			CancelInvoke ("SpawnPlatforms");
		}
	}

	void SpawnPlatforms() {
		if (GameOver) {
			return;
		}

		int rand = Random.Range (0, 6);
		if (rand < 3) {
			SpawnX ();
		} else {
			SpawnZ ();
		}
	}

	void SpawnX(){
		Vector3 pos = lastPost;
		pos.x += size;
		lastPost = pos;
		Instantiate (Platform, pos, Quaternion.identity);
		SpawnDiamond (pos);

	}

	void SpawnZ(){
		Vector3 pos = lastPost;
		pos.z += size;
		lastPost = pos;
		Instantiate (Platform, pos, Quaternion.identity);
		SpawnDiamond (pos);
	}

	void SpawnDiamond(Vector3 pos) {
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate (Diamond, new Vector3(pos.x,pos.y+1,pos.z), Diamond.transform.rotation);
		} 
	}
}
