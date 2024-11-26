using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool dansZoneVent = false;
    public GameObject zoneVent;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate(){
        if(dansZoneVent){
            rb.AddForce(zoneVent.GetComponent<WindArea>().direction * zoneVent.GetComponent<WindArea>().force);
        }
    }
    void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.tag == "windArea"){
            zoneVent = coll.gameObject;
            dansZoneVent = true;
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "windArea"){
            dansZoneVent = false;
        }
    }
}
