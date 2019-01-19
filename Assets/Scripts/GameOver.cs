using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public Text roundsText;
	public SceneFader sceneFader;
	public String menuSceneName = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnEnable() {
		roundsText.text = PlayerStats.Rounds.ToString ();
	}

	public void Retry() {
		sceneFader.FadeTo (SceneManager.GetActiveScene().name);
	}

	public void Menu() {
		sceneFader.FadeTo (menuSceneName);
		Debug.Log ("Go to menu");
	}

}
