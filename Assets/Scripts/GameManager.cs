using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public GameObject gameOverUI;

	public static bool GameIsOver;

	public string nextLevel = "Level02";
	public int levelToUnlock = 2;

	public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
		GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (GameIsOver) 
			return;

		/*
		if (Input.GetKeyDown ("e")) {
			EndGame ();
		}
		*/
		
		if (PlayerStats.Lives <= 0) {
			EndGame ();
		}
        
    }

	void EndGame() {
		GameIsOver = true;
		gameOverUI.SetActive (true);
	}

	public void WinLevel() {
		Debug.Log ("LEVEL WON !");
		PlayerPrefs.SetInt ("levelReached", levelToUnlock);
		sceneFader.FadeTo (nextLevel);
	}
}
