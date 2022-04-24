using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    int hits = 3;

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
        ClickReact();
    }

    protected override void ClickReact()
    {
        hits--;
        transform.localScale -= Vector3.one * 0.2f;
        if (hits <= 0)
            base.ClickReact();
    }
}
