using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth onUpdateHealth;

    private Animator gunAnim;

    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        } else
        {
            gunAnim.SetBool("isFiring", false);
        }
    }

    public void SendHealthData(int health)
    {
        
        if(onUpdateHealth != null)
        {
            onUpdateHealth(health);
        }
    }
}
