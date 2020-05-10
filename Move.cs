using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2;

    public GameObject gm;

    public bool isDead = false;

    Transform target;

    bool Searched = false;

    public void SetTarget(Transform build)
    {
        target = build;
        Searched = true;
    }

    void Start()
    {

    }

    void Update()
    {
        if (!isDead)
        {
            if (!Searched)
                SearchEnemy();
            else
                move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isDead = true;
            Searched = false;
        }
    }

    void SearchEnemy()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if (currDistance < nearestEnemyDistance)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = currDistance;
            }
        }

        if (nearestEnemy != null)
        {
            SetTarget(nearestEnemy);
        }
    }

    private void move()
    {
        if (target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
