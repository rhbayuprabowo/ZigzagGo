using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject Platform;

	Vector3 lastPost;
	float size;

	// Use this for initialization
	void Start () {
		lastPost = Platform.transform.position;
		size = Platform.transform.localScale.x;

		for (int i = 0; i < 10; i++) {
			SpawnZ ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnX(){
		Vector3 pos = lastPost;
		pos.x += size;
		lastPost = pos;
		Instantiate (Platform, pos, Quaternion.identity);
	}

	void SpawnZ(){
		Vector3 pos = lastPost;
		pos.z += size;
		lastPost = pos;
		Instantiate (Platform, pos, Quaternion.identity);
	}
}
