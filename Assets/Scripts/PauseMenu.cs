using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Experimental.UIElements;

public class PauseMenu : MonoBehaviour
{

	public GameObject ui;
	public SceneFader sceneFader;
	public String menuSceneName = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			Toggle ();
		}        
    }

	public void Toggle() {
		ui.SetActive (! ui.activeSelf);

		if (ui.activeSelf) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	public void Retry() {
		Toggle (); // essentially to set Timescale to 1 before reloading scene.
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu() {
		Toggle ();
		sceneFader.FadeTo (menuSceneName);
		Debug.Log ("Go to menu");
	}
}
