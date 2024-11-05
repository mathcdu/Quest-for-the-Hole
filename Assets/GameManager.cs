using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numeroTrouActuel = 0;
    public List<Transform> positionDebut;
    
    public Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody.transform.position = positionDebut[numeroTrouActuel].position;
        ballRigidbody.velocity =  Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProchainTrou(){
        numeroTrouActuel = numeroTrouActuel +1;

        if(numeroTrouActuel >= positionDebut.Count)
        {
            Debug.Log("Fin");
        }
        else{
             ballRigidbody.transform.position = positionDebut[numeroTrouActuel].position;
             ballRigidbody.velocity =  Vector3.zero;
             ballRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
