using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesLeftUI : MonoBehaviour {

    public void UpdateText(int objectivesLeft, int totalOjectives)
    {
        gameObject.GetComponent<Text>().text = string.Format("Objectives left\n{0}/{1}", objectivesLeft, totalOjectives);
    }
    public void UpdateText(int objectivesLeft)
    {
        gameObject.GetComponent<Text>().text = string.Format("Objectives left\n{0}", objectivesLeft);
    }
}
