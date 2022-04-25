using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCarrier : MonoBehaviour
{
    int finalScore;
    bool isScoreSet = false;
    public int FinalScore
    {
        get { return finalScore; }
        set
        {
            if (!isScoreSet)
            {
                finalScore = value;
                isScoreSet = true;
            }
        }
    }
    TextMeshProUGUI finalScoreText;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && finalScoreText == null)
        {
            if (SceneManager.GetActiveScene().isLoaded)
            {
                finalScoreText = GameObject.Find("Final Score Text").GetComponent<TextMeshProUGUI>();
                finalScoreText.SetText("Score: " + finalScore);
                Destroy(gameObject);
            }
        }
    }
}
