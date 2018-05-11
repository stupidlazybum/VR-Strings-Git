using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public float startingTime;
	public Puzzle[] allPuzzles;             //might be better to have LevelManager instantiate the puzzles later,
                                            //rather than enable/disable. something to implement later.
    public ShowPanels levelUIShowPanels;

    public float invincibilityDuration;

    private bool invincible;

	private int currentPuzzle = 0;
	private TimerBehaviour timer;
    private bool isLevelSolved = false;


	void Start () {
		timer = transform.GetComponentInChildren<TimerBehaviour> ();
		timer.SetAllottedTime (startingTime);
        levelUIShowPanels = GameObject.Find("UI").GetComponent<ShowPanels>();
//		Debug.LogError (timer.allottedTime);
	}
	

	void Update () {
		if (allPuzzles[currentPuzzle].isSolved == true) {       //this checks if CURRENT puzzle is solved
			UnloadPuzzle (currentPuzzle);
            ++currentPuzzle;
            if (currentPuzzle < allPuzzles.Length - 1) {        //makes sure this isn't the last puzzle
				LoadPuzzle (currentPuzzle);
			} 
			else {                                              //if it is the last puzzle...
                //this would mean you have won
                isLevelSolved = true;                           //sets the bool saying level is solved.
			}

		}


		if (CheckWinConditions()) {
			Debug.LogError ("You Win!");
            //LoadNextLevel ();
            levelUIShowPanels.ShowWinPanel();
		}
	}

	public bool CheckWinConditions () {                         //check win conditions handles...
		if (timer.timeLeft < 0) {                               //if there's time left
			return false;
		}

		for (int i = 0; i < allPuzzles.Length; i++) {           //this loop goes through all the puzzles to see if they've been solved
			if (allPuzzles[i].isSolved == false) {              //returns false on the first puzzle NOT solved.
				return false;
			}
		}

		return true;
	}

	public void LoadPuzzle (int i) {
		allPuzzles [i].gameObject.SetActive (true);
	}

	public void UnloadPuzzle (int i) {
		allPuzzles [i].gameObject.SetActive (false);
	}



	public void LoadNextLevel () {
        Debug.LogError("LoadNextLevel called");
	}

	public void LoadGameOverScreen() {

	}

    public void TakeDamage(float d)
    {
        //if(!invincible)
        if (!invincible)
        {
            timer.timeLeft -= d;
            invincible = true;
            StartCoroutine("InvincibilityCountdown");
        }

        //bool invincible = true
        //starcoroutine that counts down time.deltatime until float x amount of time has passed
        //then set invincible = false
    }

    public IEnumerator InvincibilityCountdown()
    {
        //float timeLeft = invincibilityDuration;
        //while (timeLeft > 0 )
        //{
        //    timeLeft -= Time.deltaTime;

        //    yield return null;
        //}

        yield return new WaitForSeconds(invincibilityDuration);

        invincible = false;

    }

}
