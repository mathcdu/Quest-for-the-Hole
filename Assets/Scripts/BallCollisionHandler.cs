using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public GameManager gameManager; // Référence au GameManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fin"))
        {
            Debug.Log("La balle a touché l'objet fin.");
            gameManager.FinDuJeu(); // Appelle la méthode du GameManager
        }
    }
}
