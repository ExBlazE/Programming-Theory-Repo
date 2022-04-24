using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] float spawnStartDelay = 2.0f;
    [SerializeField] float spawnDelay = 1.5f;

    float horizontalBound = 7.5f;
    float verticalBound = 4.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnStartDelay, spawnDelay);
    }

    void SpawnEnemy()
    {
        // Assumes that only 3 enemy types exist with index of 0 = easy, 1 = medium, 2 = hard
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
