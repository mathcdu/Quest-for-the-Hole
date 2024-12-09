using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        string scoreText = PlayerPrefs.GetString("scoreText", "aucun score disponible");
        resultText.text = scoreText;
    }
}
