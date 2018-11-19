using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideShowText : MonoBehaviour {

	public void Hide() {
        gameObject.GetComponent<Text>().enabled = false;
    }

    public void Show() {
        gameObject.GetComponent<Text>().enabled = true;
    }
}
