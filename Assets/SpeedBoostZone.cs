using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{

    public float boostForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        Rigidbody ballRigidBody = other.GetComponent<Rigidbody>();
        if(ballRigidBody != null)
        {
            ballRigidBody.AddForce(transform.forward * boostForce, ForceMode.Impulse);
        }
    }
}
