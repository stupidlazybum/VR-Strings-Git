using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuBehaviour : MonoBehaviour {

	//probably should initialize all the menu images here directly, 
	//so can come back and control and make all changes from here
	//create a public array of sprites that plugs it into all the children

	public Color defaultColor;
	public Color selectedColor;

	private Image[] tool;



	void Start () {
		tool = GetComponentsInChildren<Image> ();
//		Debug.LogError (tool.Length);
	}


	public void HighlightTool(int i) {
//		Debug.LogError (i);
		UnhighlightAll ();
		if (i > 0) {
			tool [i - 1].color = selectedColor;
		}


	}

	public void UnhighlightAll() {
		for (int i = 0; i < 8; i++) {
			tool [i].color = defaultColor;
		}
	}

}
