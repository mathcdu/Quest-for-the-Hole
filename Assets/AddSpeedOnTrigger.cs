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
    // Start is called before the first frame update
    void Start()
    {
        anciennePosition = transform.position;
        clubCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (transform.position - anciennePosition)/Time.deltaTime;
        anciennePosition = transform.position;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(targetTag))
        {

            Vector3 collisionPosition = clubCollider.ClosestPoint(other.transform.position);
            Vector3 collisionNormal = other.transform.position - collisionPosition;

            Vector3 projectedVelocity = Vector3.Project(velocity, collisionNormal);


            Rigidbody rb = other.attachedRigidbody;
            rb.velocity = projectedVelocity;

            gameManager.nombreCoup++;
        }
    }
}
