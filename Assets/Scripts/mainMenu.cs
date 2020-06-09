using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject instructionsMenuUI;

	// Main Menu button functions
	public void hitPlay () {
		mainMenuUI.SetActive (false);
	}

	public void hitInstructions () {
		mainMenuUI.SetActive (false);
		instructionsMenuUI.SetActive (true);
	}
		
	public void hitQuit () {
		Application.Quit();
	}

	// Instruction Menu button functions
	public void hitMenu () {
		instructionsMenuUI.SetActive (false);
		mainMenuUI.SetActive (true);
	}
}
