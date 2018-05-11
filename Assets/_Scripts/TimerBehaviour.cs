using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

	public float timeLeft;

	private Text text;
    private GameoverManager goMan;


	void Awake () {
		text = this.GetComponent<Text> ();
        goMan = GameObject.Find("UI").GetComponent<GameoverManager>();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "" + Mathf.Round (timeLeft);
		if (timeLeft < 0) {
			goMan.Gameover ();
		}
	}


	public void SetAllottedTime (float f) {
		timeLeft = f;
	}

	

}
