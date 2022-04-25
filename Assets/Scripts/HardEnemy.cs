using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
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
        if (!isAlive)
            return;
        ClickReact();
    }

    // POLYMORPHISM - METHOD OVERRIDING
    protected override void ClickReact()
    {
        hits--;
        transform.localScale -= Vector3.one * 0.2f;
        if (hits > 0)
            StartCoroutine(MoveOnClick());
        else
        {
            AddScore(enemyReward[(int)enemyLevel]);
            StartCoroutine(ExitAnim());
        }
    }

    IEnumerator MoveOnClick()
    {
        Vector3[] moveDir = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
        int randomDir = Random.Range(0, moveDir.Length);

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + moveDir[randomDir];

        float moveTime = 0.1f;
        float currentTime = 0;

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float fractionOfMove = (currentTime > moveTime) ? 1.0f : (currentTime / moveTime);
            transform.position = Vector3.Lerp(startPos, endPos, fractionOfMove);
            yield return null;
        }
    }
}
