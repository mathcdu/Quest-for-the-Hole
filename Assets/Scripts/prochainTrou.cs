using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prochainTrou : MonoBehaviour
{
    public GameManager manageJeu;
    public string tag = "ball";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(tag)){
            manageJeu.ProchainTrou();
        }
    }
}
