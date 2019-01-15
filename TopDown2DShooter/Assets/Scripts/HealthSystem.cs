using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { };

public class HealthSystem : MonoBehaviour {

    public int health = 10;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;
    public AudioClip gruntAudio;
    public AudioClip deathAudio;

    public void TakeDamage(int damage)
    {
        health -= damage;

        onDamaged.Invoke(health);

        if(GetComponent<AudioSource>() != null && gruntAudio != null) {
            GetComponent<AudioSource>().clip = gruntAudio;
            GetComponent<AudioSource>().Play();
        }

        if( health < 1 )
        {
            if (GetComponent<AudioSource>() != null && deathAudio != null) {
                GetComponent<AudioSource>().clip = deathAudio;
                GetComponent<AudioSource>().Play();
            }
            onDie.Invoke();
        }
    }
}
