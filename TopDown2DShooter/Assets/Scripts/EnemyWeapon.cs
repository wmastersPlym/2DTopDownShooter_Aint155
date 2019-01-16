using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyWeapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public int roundsPerMag = 6;
    public float realoadTime = 2f;
    public AudioClip shootAudio;
    public AudioClip reloadAudio;
    public int distanceToShoot;
    


    private bool isFiring = false;
    private bool isReloading = false;
    private int roundsLeft = 0;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        roundsLeft = roundsPerMag;
    }

    void SetFiring()
    {
        isFiring = false;
    }

    
    void Realoading() {
        
        roundsLeft = roundsPerMag;
        isFiring = false;
        isReloading = false;
    }

    void StartRealoding() {
        isReloading = true;
        audioSource.clip = reloadAudio;
        audioSource.Play();
        Invoke("Realoading", realoadTime);
    }
	
    void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        roundsLeft--;
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
    private void Update()
    {
        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) < distanceToShoot) { // if close enough to the player


            if(roundsLeft > 0) { // if has enough rounds left
                if (!isFiring && !isReloading) {
                    Fire();
                }
            } else if(!isReloading){
                StartRealoding();
            }
            
        }
    }
}
