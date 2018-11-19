using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public int roundsPerMag = 6;
    public float realoadTime = 2f;
    public GameObject realoadUIText;

    private bool isFiring = false;
    public int roundsLeft = 0;

    private void Start() {
        roundsLeft = roundsPerMag;
        realoadUIText = GameObject.Find("txtRealoding");
        realoadUIText.GetComponent<HideShowText>().Hide();
    }

    void SetFiring()
    {
        isFiring = false;
    }

    
    void Realoading() {
        isFiring = false;
        roundsLeft = roundsPerMag;
        print("FinishedRealoading");
        realoadUIText.GetComponent<HideShowText>().Hide();
    }

    void StartRealoding() {
        realoadUIText.GetComponent<HideShowText>().Show();
        Invoke("Realoading", realoadTime);
    }
	
    void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        roundsLeft--;
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        if (roundsLeft <= 0) {
            StartRealoding();
        } else {
            Invoke("SetFiring", fireTime);
        }

    }

    private void Update()
    {
        if(Input.GetMouseButton(0) )
        {
            if(!isFiring)
            {
                Fire();
            }
        }
        if(Input.GetKeyDown("r")) {
            StartRealoding();
        }
    }
}
