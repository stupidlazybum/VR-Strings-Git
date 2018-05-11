using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCordBehaviour : MonoBehaviour {

	private LineRenderer lineR;
//	private bool isTouched = false;

//	public GameObject rControllerPos;
	private Vector3 spherePos;
	private GameObject sphere;
	private Transform grabberPos;
	private Vector3 offset;
	private bool isCentered = true;

    private ButtonControls butCon;

	public bool isGrabbed = false;
	private float smoothing = 5f;

	// Use this for initialization
	void Start () {
		sphere = transform.parent.gameObject;
		lineR = GetComponent<LineRenderer> ();
        butCon = GameObject.Find("My Player").GetComponent<ButtonControls>();

	}
	
	// Update is called once per frame
	void Update () {
		spherePos = sphere.transform.position;
		lineR.SetPosition (0, this.transform.position);
//		lineR.SetPosition (1, rControllerPos.transform.position);
		lineR.SetPosition (1, spherePos);

		if (isGrabbed == true) {
			transform.position = grabberPos.position - offset;
            butCon.VibrateRCon();       //haptic feedback
		}

		if (Vector3.Distance(transform.position, spherePos) > 0.05f) {
			isCentered = false;
		}

		if (!isGrabbed && !isCentered) {
			StopCoroutine ("ReCenter");
			StartCoroutine ("ReCenter");
		}
	}

	private IEnumerator ReCenter () {
		while (Vector3.Distance(transform.position, spherePos) > 0.01f) {
			transform.position = Vector3.Lerp (transform.position, spherePos, smoothing * Time.deltaTime);

			yield return null;
		}

		isCentered = true;

	}

	public void SetOffset (Vector3 dist) {
		offset = dist;
	}

	public void SetGrabber (Transform trans) {
		//controller:  0 = Left Con, 1 = Right Con
//		isGrabbed = grabbed;
		grabberPos = trans;

	}
//	void OnTriggerStay (Collider other) {
//		if (other.tag == "LeftHand" || other.tag == "RightHand") {
//			isTouched = true;
//		}
//	}
//
//	void OnTriggerExit (Collider other) {
//		isTouched = false;
//	}


}
