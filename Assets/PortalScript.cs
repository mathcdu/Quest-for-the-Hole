using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform ball, destination;
    public GameObject ballg;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ballg.SetActive(false);

            ball.position = destination.position;

            ballg.SetActive(true);
        }
    }
}
