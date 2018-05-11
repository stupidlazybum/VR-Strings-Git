using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CurvedUI;

public class ButtonControls : MonoBehaviour {

    //	private GameObject conAnchorL;
    //	private GameObject conAnchorR;

    [SerializeField]
    OculusHapticsController leftControllerHaptics;

    [SerializeField]
    OculusHapticsController rightControllerHaptics;

    public GameObject laserL;
	public GameObject laserR;

	public GameObject menuL;
	public ToolsSelector toolsR;

	public int selectedTool = 1;

    private LevelManager lMan;

	void Start () {
        //		conAnchorL = transform.Find ("LeftHandAnchor").gameObject;
        //		conAnchorR = transform.Find ("RightHandAnchor").gameObject;

        //		if (conAnchorL == null || conAnchorR == null) {
        //			Debug.LogError ("u dun goofed");
        //		}

        lMan = GameObject.Find("Level Manager").GetComponent<LevelManager>();

	}

	void Update () {

		//A Button on R Controller
		//Turns on Laser Pointer
		//probably a temp function for now.
		if (OVRInput.Get(OVRInput.Button.Two)) {
//			Debug.LogError ("u pressed A");
//			conAnchorR.transform.Find ("ControllerLaserPointer").gameObject.SetActive (true);
			laserR.SetActive(true);
		} 
		else {
//			conAnchorR.transform.Find ("ControllerLaserPointer").gameObject.SetActive (false);
			laserR.SetActive(false);
		}


		//X Button on L Controller
		//Turns on Laser Pointer
		//probably a temp function for now.
		if (OVRInput.Get(OVRInput.Button.Four)) {
			laserL.SetActive(true);
		} 
		else {
			laserL.SetActive(false);
		}


        if (Input.GetKey(KeyCode.Space))    //spacebar debug========================================================
        {
            leftControllerHaptics.Vibrate(VibrationForce.Hard);
            rightControllerHaptics.Vibrate(VibrationForce.Light);
        }

		//Start button on L Controller
			//put the control for start button in the Pause script from the Game Jam package that controls UI


		//Trigger on L Controller & R Controller
			//pulls node to controller
				//changed my mind, let's put this in CUI_ViveLaserBeam
//		if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && laserL.GetComponent<CUI_ViveLaserBeam>().IsHittingNode()) {
//			
//		}



		//D-pad on L Controller
			//opens menu and sets tool
		Vector2 dPadLeft = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
		if (dPadLeft.x != 0f || dPadLeft.y != 0f) {
			menuL.SetActive (true);
			SelectTool(dPadLeft);
			menuL.GetComponent<ItemMenuBehaviour> ().HighlightTool (selectedTool);
			toolsR.SelectTool (selectedTool);
//			Debug.LogError ("x: " + dPadLeftConX + " and y: " + dPadLeftConY);
			//SelectTool(Vector2) -> this changes a variable (int?) called selectedTool
									//maybe make it an public array of strings for clarity of code down the line?
//			Debug.LogError (selectedTool);

		} 
		else {
			menuL.SetActive (false);
		}



	}

    public void VibrateRCon()
    {
        rightControllerHaptics.Vibrate(VibrationForce.Light);
    }


	public void SelectTool(Vector2 dPadInput) {
		float x = dPadInput.x;
		float y = dPadInput.y;

		//selected tool starts top, goes clockwise from 1 to 8

		if (y > .8f && x < .3f && x > -.3f) { 				//North
			selectedTool = 1;
		}
		if (x > .8f && y < .3f && y > -.3f) {				//East
			selectedTool = 3;
		}
		if (y < -.8f && x < .3f && x > -.3f) { 				//South
			selectedTool = 5;
		}
		if (x < -.8f && y < .3f && y > -.3f) {				//West
			selectedTool = 7;
		}
		if (y > .3f && y < .8f && x > .3f && x < .8f) {		//NorthEast
			selectedTool = 2;
		}
		if (y < -.3f && y > -.8f && x > .3f && x < .8f) {		//SouthEast
			selectedTool = 4;
		}
		if (y < -.3f && y > -.8f && x < -.3f && x > -.8f) {		//SouthWest
			selectedTool = 6;
		}
		if (y > .3f && y < .8f && x < -.3f && x > -.8f) {		//NorthWest
			selectedTool = 8;
		}
	}


}
