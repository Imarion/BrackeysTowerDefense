using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSelector : MonoBehaviour
{

	public SceneFader fader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Select(String levelName) {
		fader.FadeTo (levelName);
	}
}
