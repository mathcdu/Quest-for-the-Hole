using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    public float boostForce = 20f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();
        if (ballRigidBody != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();


            ballRigidBody.AddForce(direction * boostForce, ForceMode.Impulse);
        }
    }
}
