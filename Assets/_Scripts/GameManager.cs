using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int currentLvl;

	void Awake () {
		DontDestroyOnLoad (this);
//		SceneManager.sceneLoaded += TestMethod;			//can't figure out why this isn't working, but fuck it
	}

	void Update () {
		
	}

//	void OnDestroy () {
//		SceneManager.sceneLoaded -= TestMethod;
//	}

//	public void TestMethod () {
//		Debug.LogError ("test");
//	}


}
