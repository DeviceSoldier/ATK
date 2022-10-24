using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchSEControl : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip SE1;
    public AudioClip SE2;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            audio.PlayOneShot(SE1);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(SE2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
        }
    }
}
