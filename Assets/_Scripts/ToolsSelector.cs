using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSelector : MonoBehaviour {

	private Transform[] tools;

	void Start () {
		tools = GetComponentsInChildren<Transform> ();
		ResetTools ();
	}

	public void ResetTools() {

//		Debug.Log (tools.Length);
		for (int i = 1; i < tools.Length; i++) {			//i set to 1 to not disable parent object
			tools [i].gameObject.SetActive (false);
		}
	}

	public void SelectTool (int i) {
		Debug.LogError ("select tool: " + i);
		ResetTools ();
		tools [i].gameObject.SetActive (true);
	}

}
