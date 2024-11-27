using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemiseBalle : MonoBehaviour
{
    private GameManager gestionnaireDeJeu;
    private Rigidbody balleRigidbody;

    void Start()
    {
        // Trouver le GameManager dans la scène
        gestionnaireDeJeu = FindObjectOfType<GameManager>();
        balleRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la balle touche le sol
        if (collision.collider.CompareTag("Ground"))
        {
            RemettrePositionBalle();
        }
    }

    private void RemettrePositionBalle()
    {
        // Obtenir la position de départ du trou actuel depuis le GameManager
        Vector3 positionDepart = gestionnaireDeJeu.ObtenirPositionDebutTrouActuel();
        
        // Réinitialiser la position et la vélocité de la balle
        balleRigidbody.position = positionDepart;
        balleRigidbody.velocity = Vector3.zero;
        balleRigidbody.angularVelocity = Vector3.zero;

        Debug.Log("Balle remise au début du trou actuel.");
    }
}