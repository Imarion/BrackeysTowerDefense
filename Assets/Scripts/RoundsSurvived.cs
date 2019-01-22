using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{

	public Text roundsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnEnable() {
		StartCoroutine (AnimateText());
	}

	IEnumerator AnimateText() {
		roundsText.text = "0";
		int round = 0;

		yield return new WaitForSeconds (.7f);

		while (round <  PlayerStats.Rounds ) {
			round++;
			roundsText.text = round.ToString ();
			yield return new WaitForSeconds (.05f);
		}
	}
}
