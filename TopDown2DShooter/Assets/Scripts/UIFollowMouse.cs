using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowMouse : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.position = Input.mousePosition + new Vector3(0, -50);
	}
}
