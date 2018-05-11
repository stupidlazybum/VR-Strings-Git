using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeNetPuzzle : Puzzle {

	public Node[] nodes;

	void Start () {
		nodes = GetComponentsInChildren<Node> ();
		isSolved = false;
	}

	void Update () {
		if (CheckSolveConditions()) {
			isSolved = true;
		}
	}


	public bool CheckSolveConditions () {
		for (int i = 0; i < nodes.Length; i++) {
			if (nodes [i].isActive == false) {
				return false;
			}
		}
		return true;
	}


}
