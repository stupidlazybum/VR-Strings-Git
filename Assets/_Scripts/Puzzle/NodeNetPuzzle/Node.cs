using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public bool isActive;
	public bool isCurrent;
	public Material activeMat;
	public Material inactiveMat;

	private Renderer rend;
	private GameObject lightOrigin;
	private Transform previousNode;

	private LineRenderer lineRend;
	private bool isPreceded;

	void Start() {
		lightOrigin = this.GetComponentInChildren<NodeCordBehaviour> ().transform.gameObject;
		rend = GetComponent<Renderer> ();

		if (isCurrent) {
			SetNodeAsCurrent ();
		} 
		else {
			DeactivateNode ();
			lightOrigin.SetActive (false);
		}

		lineRend = GetComponent<LineRenderer> ();
		lineRend.enabled = false;
	}


	void Update() {
		if (isPreceded) {
			lineRend.SetPosition (0, this.transform.position);
			lineRend.SetPosition (1, previousNode.position);
		}
	}





	public void ActivateNode() {
		isActive = true;
		rend.material = activeMat;
	}

	public void DeactivateNode() {
		isActive = false;
		rend.material = inactiveMat;
	}

	public void SetNodeAsCurrent () {
		ActivateNode ();
		isCurrent = true;
		lightOrigin.SetActive (true);
	}

	public void SetNodeAsNotCurrent() {
		isCurrent = false;
		lightOrigin.SetActive (false);
	}



	void OnTriggerEnter (Collider other) {
		if (other.tag == "Spark") {
			isPreceded = true;
			previousNode = other.transform.parent;
			lineRend.enabled = true;
//			other.gameObject.SetActive (false);
			other.GetComponentInParent<Node>().SetNodeAsNotCurrent();
			SetNodeAsCurrent ();
		}
	}

}
