using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOnTrigger : MonoBehaviour
{
    public string targetTag;
    public GameManager gameManager;
    private Vector3 anciennePosition;
    private Vector3 velocity;

    private Collider clubCollider;

    void Start()
    {
        anciennePosition = transform.position;
        clubCollider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        velocity = (transform.position - anciennePosition) / Time.fixedDeltaTime;
        anciennePosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rb = other.attachedRigidbody;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            Vector3 collisionPosition = clubCollider.ClosestPoint(other.transform.position);
            Vector3 collisionNormal = other.transform.position - collisionPosition;

            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNormal);
            
            Vector3 direction;
            float distance;
            if (Physics.ComputePenetration(
                    clubCollider, clubCollider.transform.position, clubCollider.transform.rotation,
                    other, other.transform.position, other.transform.rotation,
                    out direction, out distance))
            {
                // Resolve penetration by moving the ball out of the club
                other.transform.position += direction * distance;
            }

            rb.velocity = projectedVelocity;

            gameManager.nombreCoup++;
        }
    }
}
