using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MediumEnemy : Enemy
{
    int hits = 2;

    void Start()
    {
        StartCoroutine(SpawnAnim());
    }

    void Update()
    {
        LifeTimer();
        IdleAnim();
    }

    void OnMouseDown()
    {
        if (!isAlive)
            return;
        ClickReact();
    }

    // POLYMORPHISM - METHOD OVERRIDING
    protected override void ClickReact()
    {
        hits--;
        transform.localScale -= Vector3.one * 0.25f;
        if (hits <= 0)
        {
            AddScore(enemyReward[(int)enemyLevel]);
            StartCoroutine(ExitAnim());
        }
    }
}
