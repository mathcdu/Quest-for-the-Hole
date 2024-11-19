using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    private int numeroTrouActuel = 0;
    public List<Transform> positionDebut;
    
    public Rigidbody ballRigidbody;

    public TMPro.TextMeshPro textScoreTm;

    public int nombreCoup = 0;
    private List<int> nombreCoupPrecedent = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody.transform.position = positionDebut[numeroTrouActuel].position;
        ballRigidbody.velocity =  Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        textScoreTm.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame){
            ProchainTrou();
        }
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
        nombreCoupPrecedent.Add(nombreCoup);
        nombreCoup = 0;
        AfficherPointage();
    }

    public void AfficherPointage()
    {

        string textScore = "";
        for (int i = 0; i  < nombreCoupPrecedent.Count; i++)
        {
            textScore += "Trou" + (i + 1) + " - " + nombreCoupPrecedent[i];
        }
            textScoreTm.text = textScore;

    }
}
