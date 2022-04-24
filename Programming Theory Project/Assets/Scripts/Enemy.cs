using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected enum Level { easy, medium, hard };
    protected int[] enemyReward = { 1, 2, 5 };

    [SerializeField] protected Level enemyLevel;
    [SerializeField] protected float lifeSpan; // Set in editor for all enemies.
    protected bool isAlive = true;

    private float idleRotationSpeed = 180.0f;
    private float appearTime = 0.1f;
    private float vanishTime = 0.1f;

    protected void LifeTimer()
    {
        if (isAlive)
            lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0 && isAlive)
        {
            StartCoroutine(ExitAnim());
        }
    }

    protected virtual void ClickReact()
    {
        AddScore();
        StartCoroutine(ExitAnim());
    }

    protected void AddScore()
    {
        GameManager.Instance.Score++;
    }

    // POLYMORPHISM - METHOD OVERLOADING
    protected void AddScore(int score)
    {
        GameManager.Instance.Score += score;
    }

    // ABSTRACTION
    protected void IdleAnim()
    {
        transform.Rotate(Vector3.forward, idleRotationSpeed * Time.deltaTime);
    }

    protected IEnumerator SpawnAnim()
    {
        transform.localScale = Vector3.zero;
        float progress = transform.localScale.x;

        while (progress < 1.0f)
        {
            float scaleChange = Time.deltaTime / appearTime;
            transform.localScale += Vector3.one * scaleChange;
            progress = transform.localScale.x;
            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    protected IEnumerator ExitAnim()
    {
        isAlive = false;
        if (lifeSpan <= 0)
            GameManager.Instance.Lives--;
        float progress = transform.localScale.x;

        while (progress > 0.01f)
        {
            float scaleChange = Time.deltaTime / vanishTime;
            transform.localScale -= Vector3.one * scaleChange;
            progress = transform.localScale.x;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
