using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour {

    public UnityEvent pickUp;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            pickUp.Invoke();
        }
    }
}
