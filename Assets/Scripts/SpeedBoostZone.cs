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
            // Utiliser la direction de mouvement actuelle de la balle
            Vector3 direction = ballRigidBody.velocity.normalized;

            if (direction != Vector3.zero)
            {
                // Appliquer la force dans la direction de mouvement
                ballRigidBody.AddForce(direction * boostForce, ForceMode.Impulse);
            }
            else
            {
                // Si la balle est immobile, on applique une force par défaut (facultatif)
                Debug.LogWarning("La balle est immobile, pas de boost appliqué.");
            }
        }
    }
}
