using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform ball, destination;
    public GameObject ballg;
    public AudioClip teleportSound;
    private AudioSource audioSource;

    void Start()
    {
        // Create AudioSource once
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ballg.SetActive(false);
            ball.position = destination.position;
            ballg.SetActive(true);

            // Play sound
            audioSource.PlayOneShot(teleportSound);
        }
    }
}
