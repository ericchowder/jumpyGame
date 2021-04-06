using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSpawner : MonoBehaviour {	

	public GameObject bgPrefab;

	// the time that it will spawn
	public float spawnTime = 2f;
	// interval of time between spawns
	public float spawnInterval = 4f;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		// platforms spawn when whenever new interval is hit
		if (Time.time >= spawnTime) {
			SpawnBackground();
			spawnTime = Time.time + spawnInterval;
		}
	}

	void SpawnBackground() {
		GameObject bgInstance = Instantiate(bgPrefab,
			gameObject.transform.position, Quaternion.identity);
		bgInstance.SetActive(true);
	}
}
