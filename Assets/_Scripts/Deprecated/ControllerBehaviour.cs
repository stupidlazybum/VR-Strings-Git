using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBehaviour : MonoBehaviour {

	void OnTriggerStay (Collider other) {
		if ( (OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) || 
				(OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
																											) {

			other.gameObject.GetComponentInChildren<LineRenderer> ().enabled = true;

		} 

		else {
			other.gameObject.GetComponentInChildren<LineRenderer> ().enabled = false;
		}
	}

}
