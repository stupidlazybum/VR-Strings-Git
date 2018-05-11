using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CurvedUI
{
    /// <summary>
    /// This class contains code that controls the mockup vive controller. 
    /// Its made to make demo sceen look better. Its not made to be used with actual vive controller.
    /// </summary>
    public class CUI_ViveLaserBeam : MonoBehaviour
    {

        [SerializeField]
        Transform LaserBeamTransform;
        [SerializeField]
        Transform LaserBeamDot;

		public float magnetSpeed;
        private LevelManager lMan;

        private void Awake()
        {
            lMan = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        }

        // Update is called once per frame
        protected void Update()
        {
            var lTrigVal = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);  //u made dis?...i made dis
            var rTrigVal = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);  //u made dis?...i made dis
            //get direction of the controller
            Ray myRay = new Ray(this.transform.position, this.transform.forward);


            //make laser beam hit stuff it points at.
            if(LaserBeamTransform && LaserBeamDot) {
                //change the laser's length depending on where it hits
                float length = 10000;

                RaycastHit hit;
                if (Physics.Raycast(myRay, out hit, length))
                {
//					Debug.LogError ("hit something");
                    length = Vector3.Distance(hit.point, this.transform.position);

                    //If we hit a canvas, we only want transforms with graphics to block the pointer. (that are drawn by canvas => depth not -1)
                    if (hit.transform.GetComponent<CurvedUIRaycaster>() != null)  {
                        int SelectablesUnderPointer = hit.transform.GetComponent<CurvedUIRaycaster>().GetObjectsUnderPointer().FindAll(x => x.GetComponent<Graphic>() != null && x.GetComponent<Graphic>().depth != -1).Count;

                        //Debug.Log("found graphics: " + SelectablesUnderPointer);
                        length = SelectablesUnderPointer == 0 ? 10000 : Vector3.Distance(hit.point, this.transform.position);
                    }  
//my code begin====================================================================================================================
					if (hit.transform.GetComponent<Rigidbody>() != null && lTrigVal && hit.transform.gameObject.tag != "NonMagnetic") {
						Debug.LogError ("magnet called");
						hit.transform.position = Vector3.Lerp (hit.transform.position, this.transform.position, Time.deltaTime * magnetSpeed);
					} 
					else if (hit.transform.gameObject.GetComponent<Rigidbody>() != null && rTrigVal && hit.transform.gameObject.tag != "NonMagnetic") {
						Debug.LogError ("magnet called");
						hit.transform.position = Vector3.Lerp (hit.transform.position, this.transform.position, Time.deltaTime * magnetSpeed);
					}

                    if (hit.transform.GetComponent<Rigidbody>() != null && lTrigVal && hit.transform.gameObject.tag == "NonMagnetic")
                    {
                        Debug.LogError("MISS! Take Damage");
                        lMan.TakeDamage(10f);
                        //hit.transform.position = Vector3.Lerp(hit.transform.position, this.transform.position, Time.deltaTime * magnetSpeed);
                    }
                    else if (hit.transform.gameObject.GetComponent<Rigidbody>() != null && rTrigVal && hit.transform.gameObject.tag == "NonMagnetic")
                    {
                        Debug.LogError("MISS! Take Damage");
                        lMan.TakeDamage(10f);
                        //hit.transform.position = Vector3.Lerp(hit.transform.position, this.transform.position, Time.deltaTime * magnetSpeed);
                    }

//my code end======================================================================================================================
                }

                LaserBeamTransform.localScale = LaserBeamTransform.localScale.ModifyZ(length);
            }
           

        }

    }
}
