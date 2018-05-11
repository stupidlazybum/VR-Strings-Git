using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkScrew : MonoBehaviour {

//	private Vector3 offsetDistance;
//	private Transform sphereParentTran;

	void OnTriggerStay (Collider other) {
		Debug.LogError (other.tag);
		if (other.tag == "Spark") {
			Debug.LogError ("Spark called");
			if (OVRInput.Get(OVRInput.Button.One) && other.GetComponent<NodeCordBehaviour>().isGrabbed == false) {
				other.GetComponent<NodeCordBehaviour>().SetOffset(transform.position - other.transform.position);
				other.GetComponent<NodeCordBehaviour> ().SetGrabber (transform);
				other.GetComponent<NodeCordBehaviour> ().isGrabbed = true;

//				offsetDistance = transform.position - other.transform.position;
//				other.transform.position = transform.position + offsetDistance;

//				sphereParentTran = other.GetComponentInParent<Transform> ();
//				other.transform.SetParent (transform);
			} 
			else if (OVRInput.Get(OVRInput.Button.One) && other.GetComponent<NodeCordBehaviour>().isGrabbed == true) {
				Debug.LogError ("IS pressing button & IS Grabbed.");
			}
			else if (!OVRInput.Get(OVRInput.Button.One) && other.GetComponent<NodeCordBehaviour>().isGrabbed == true) {
				Debug.LogError ("NOT pressing button & IS grabbed");
//				other.transform.SetParent (sphereParentTran);
				other.GetComponent<NodeCordBehaviour> ().isGrabbed = false;
			}
			else {
				Debug.LogError ("huh?");
			}
		}
	}



}
