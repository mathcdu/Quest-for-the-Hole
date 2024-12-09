using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneTrigger : MonoBehaviour
{
    // Vérifie la collision avec l'XR Origin ou un objet similaire
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est l'XR Origin qui entre dans la zone
        if (other.CompareTag("joueur"))  // Assure-toi que ton XR Origin a le bon tag
        {
            Debug.Log("Zone Trigger activée, changement de scène.");
            // Charge la scène nommée "Résultats"
            SceneManager.LoadScene("Mathi_Enviro");
        }
    }
}
