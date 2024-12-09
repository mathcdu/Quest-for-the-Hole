using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int numeroTrouActuel = 0;
    public List<Transform> positionDebut;

    public Rigidbody ballRigidbody;
    public Transform xrOrigin;

    public TextMeshPro textScoreTm;

    public int nombreCoup = 0;
    private List<int> nombreCoupPrecedent = new List<int>();

    public Vector3 playerOffset = new Vector3(1f, 0f, 0f);
    public float distanceScoreJoueur = 2.0f;

    void Start()
    {
        ResetBallAndPlayer();
        textScoreTm.text = "";
        
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ProchainTrou();
        }
    }

    public int ObtenirNumeroTrouActuel()
    {
        return numeroTrouActuel;
    }

    public Vector3 ObtenirPositionDebutTrouActuel()
    {
        return positionDebut[numeroTrouActuel].position;
    }

    public void ProchainTrou()
    {
        numeroTrouActuel = numeroTrouActuel + 1;

        if (numeroTrouActuel >= positionDebut.Count)
        {
            Debug.Log("Fin");
        }
        else
        {
            ResetBallAndPlayer();
        }

        nombreCoupPrecedent.Add(nombreCoup);
        nombreCoup = 0;
        AfficherPointage();
    }

    public void ResetBallAndPlayer()
    {
        ballRigidbody.transform.position = positionDebut[numeroTrouActuel].position;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;

        Debug.Log("Ball position reset to " + positionDebut[numeroTrouActuel].position);

        if (xrOrigin != null)
        {
            Vector3 playerStartPosition = positionDebut[numeroTrouActuel].position + playerOffset;
            xrOrigin.position = playerStartPosition;
            Debug.Log("Player position reset to " + playerStartPosition);
        }
        else
        {
            Debug.LogError("xrOrigin is not assigned in the Inspector.");
        }
    }

    public void AfficherPointage()
    {
        string textScore = "";
        for (int i = 0; i < nombreCoupPrecedent.Count; i++)
        {
            textScore += "Trou" + (i + 1) + " - " + nombreCoupPrecedent[i] + "\n";
        }
        textScoreTm.text = textScore;
    }

    // Nouvelle méthode pour détecter la collision avec l'objet fin
public void FinDuJeu()
{
    Debug.Log("Chargement de la scène Résultats...");

    // Save the score data in PlayerPrefs
    string scoreText = "";
    for (int i = 0; i < nombreCoupPrecedent.Count; i++)
    {
        scoreText += "Trou" + (i + 1) + " - " + nombreCoupPrecedent[i] + "\n";
    }
    PlayerPrefs.SetString("scoreText", scoreText);
    PlayerPrefs.Save();

    // Load the Results scene
    SceneManager.LoadScene("Résultat");
}
}
