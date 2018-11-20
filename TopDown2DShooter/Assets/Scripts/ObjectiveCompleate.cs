using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCompleate : MonoBehaviour {

    public void CompleateObjective()
    {
        //print("ObjectiveCompleate");
        GameObject.Find("Game System").GetComponent<GameManager>().UpdateObjectives();
    }
}
