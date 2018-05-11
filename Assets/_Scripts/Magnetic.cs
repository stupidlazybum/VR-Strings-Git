using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Magnetic : VRTK_InteractableObject {

    public float magnetSpeed = 10f;

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);

        Debug.LogError("start using called");

        StartCoroutine(MoveTowardsController(currentUsingObject));
        

    }

    public IEnumerator MoveTowardsController(VRTK_InteractUse currentUsingObject)
    {
        while (Vector3.Distance(this.transform.position, currentUsingObject.transform.position) > 0.05f && IsUsing())
        {
            this.transform.position = Vector3.Lerp(this.transform.position, currentUsingObject.transform.position, Time.deltaTime * magnetSpeed);

            yield return null;
        }

    }

    //public override void StartUsing(GameObject currentUsingObject)      //seems like this method has been deprecated
    //{
    //    base.StartUsing(currentUsingObject);

    //    Debug.LogError("startusing gameobject called");
    //}
}
