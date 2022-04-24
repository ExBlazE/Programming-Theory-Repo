using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ClickReact();
    }

    protected override void ClickReact()
    {
        hits--;
        transform.localScale -= Vector3.one * 0.25f;
        if (hits <= 0)
            base.ClickReact();
    }
}
