using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EasyEnemy : Enemy
{
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
}
