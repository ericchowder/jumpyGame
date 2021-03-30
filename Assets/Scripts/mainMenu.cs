using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject instructionsMenuUI;
	public GameObject spawnerActive;
	public GameObject bgSpawner;
	public GameObject startingPlatform;
	public Rigidbody2D startingPlatformRB;

	void Awake() {
		spawnerActive.SetActive (false);
		startingPlatformRB.constraints = RigidbodyConstraints2D.FreezeAll;
		startingPlatform.GetComponent<platformMovement> ().enabled = false;
	}

	// Main Menu button functions
	public void hitPlay() {
		mainMenuUI.SetActive(false);
		spawnerActive.SetActive(true);
		startingPlatform.GetComponent<platformMovement> ().enabled = true;
	}

	public void hitInstructions () {
		mainMenuUI.SetActive (false);
		instructionsMenuUI.SetActive (true);
	}
		
	public void hitQuit() {
		Application.Quit();
	}

	// Instruction Menu button functions
	public void hitMenu() {
		instructionsMenuUI.SetActive(false);
		mainMenuUI.SetActive(true);
	}

	// Losing Menu button functions
	public void restartGame() {
		SceneManager.LoadScene("mainGameScene");
	}
}
