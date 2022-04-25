using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] GameObject[] enemies;
    [SerializeField] float spawnStartDelay = 2.0f;
    [SerializeField] float spawnDelay = 1.5f;

    float horizontalBound = 7.5f;
    float verticalBound = 4.5f;

    // ENCAPSULATION
    int lives = 3;
    int currentLives;
    public int Lives
    {
        get { return lives; }
        set
        {
            if ((lives - value > 1) || (value > lives))
                return;
            else
                lives = value;
        }
    }

    // ENCAPSULATION
    int score;
    int currentScore;
    public int Score
    {
        get { return score; }
        set
        {
            if (value < score)
                return;
            else
                score = value;
        }
    }

    [Space]

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        score = 0;
        InvokeRepeating(nameof(SpawnEnemy), spawnStartDelay, spawnDelay);
    }

    void Update()
    {
        if (currentScore != score)
        {
            currentScore = score;
            scoreText.SetText("SCORE\n" + currentScore);
        }

        if (currentLives != lives)
        {
            currentLives = lives;
            livesText.SetText("LIVES\n" + currentLives);
        }

        if (lives <= 0 && Time.timeScale > 0)
        {
            CancelInvoke();
            Time.timeScale = 0;
        }
    }

    void SpawnEnemy()
    {
        // Assumes that only 3 enemy types exist with prefab index of 0 = easy, 1 = medium, 2 = hard
        // Done to give more spawn priority to easier enemies
        int index;
        float spawnLevel = Random.value;
        if (spawnLevel < 0.5f)
            index = 0;
        else if (spawnLevel < 0.8f)
            index = 1;
        else
            index = 2;
        Instantiate(enemies[index], GenerateSpawnPos(), Quaternion.identity);
    }

    // ABSTRACTION
    Vector3 GenerateSpawnPos()
    {
        float xPos = Random.Range(-horizontalBound, horizontalBound);
        float yPos = Random.Range(-verticalBound, verticalBound);
        return new Vector3(xPos, yPos, 0);
    }
}
