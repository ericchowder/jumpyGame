using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerController : MonoBehaviour {

	// instance of timeController
	public static timerController instance;
	// text for timeCounter
	public Text timeCounter;
	// time format
	private TimeSpan timePlaying;
	// timer on or off
	private bool timerGoing;

	private float elapsedTime;

	void Awake() {
		instance = this;
	}
		
	// Use this for initialization
	void Start() {
		timeCounter.text = "Time: 00:00.00";
		timerGoing = false;
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	// Starts game timer
	public void BeginTimer() {
		timerGoing = true;
		elapsedTime = 0f;

		StartCoroutine(UpdateTimer());
	}

	// Ends game timer
	public void EndTimer() {
		timerGoing = false;
	}

	private IEnumerator UpdateTimer() {
		while (timerGoing)
		{
			// Summation of Time.deltaTime (which is time from previous frame to current frame)
			elapsedTime += Time.deltaTime;
			// Converts seconds into TimeSpan
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string fmt = "mm':'ss':'ff";
			// Formats time into string
			string timePlayingStr = "Time: " + timePlaying.ToString();
			// Sets gameobject
			timeCounter.text = timePlayingStr;

			// Returns to this point of coroutine on next frame
			yield return null;
		}
	}
}
