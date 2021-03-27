using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour {

	public GameObject platformPrefab;

	// the time that it will spawn
	public float spawnTime = 2f;
	// interval of time between spawns
	public float spawnInterval = 1f;

	void Start () {
		
	}

	void Update () {
		// platforms spawn when whenever new interval is hit
		if (Time.time >= spawnTime) {
			SpawnPlatforms ();
			spawnTime = Time.time + spawnInterval;
		}
	}

	void SpawnPlatforms () {
		// Create new platform
		GameObject platformInstance = Instantiate (platformPrefab, 
			gameObject.transform.position, Quaternion.identity);
		// Assign to platforms layer
		platformInstance.layer = LayerMask.NameToLayer("platforms");
	}
}
