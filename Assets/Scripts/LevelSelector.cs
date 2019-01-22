using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

	public SceneFader fader;

	public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		for (int i = 0; i < levelButtons.Length; i++) {
			if (i + 1 > levelReached)
				levelButtons [i].interactable = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Select(String levelName) {
		fader.FadeTo (levelName);
	}
}
