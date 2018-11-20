using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public int roundsPerMag = 6;
    public float realoadTime = 2f;
    public GameObject realoadUIText;
    public Text ammoText;

    private bool isFiring = false;
    private int roundsLeft = 0;

    private void Start() {
        roundsLeft = roundsPerMag;
        realoadUIText = GameObject.Find("txtRealoding");
        realoadUIText.GetComponent<HideShowText>().Hide();
        UpdateBulletsLeftText();
    }

    void SetFiring()
    {
        isFiring = false;
    }

    
    void Realoading() {
        isFiring = false;
        roundsLeft = roundsPerMag;
        //print("FinishedRealoading");
        realoadUIText.GetComponent<HideShowText>().Hide();
        UpdateBulletsLeftText();
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
        UpdateBulletsLeftText();
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
    void UpdateBulletsLeftText()
    {
        if(ammoText != null)
        {
            ammoText.text = string.Format("Ammo: {0}/{1}", roundsLeft, roundsPerMag);
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
