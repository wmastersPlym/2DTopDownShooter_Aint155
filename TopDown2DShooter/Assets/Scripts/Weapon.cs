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
    public AudioClip shootAudio;
    public AudioClip reloadAudio;
    


    private bool isFiring = false;
    private bool isReloading = false;
    private int roundsLeft = 0;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
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
        isReloading = false;
        roundsLeft = roundsPerMag;
        realoadUIText.GetComponent<HideShowText>().Hide();
        UpdateBulletsLeftText();
    }

    void StartRealoding() {
        isReloading = true;
        audioSource.clip = reloadAudio;
        audioSource.Play();
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

            audioSource.clip = shootAudio;
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
            if(!isFiring && !isReloading)
            {
                Fire();
            }
        }
        if(Input.GetKeyDown("r") && !isReloading) {
            StartRealoding();
        }
    }
}
