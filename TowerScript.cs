using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    float range = 3;
    private float CurrCooldown;
    public float Cooldown;

    public GameObject Projectile;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    bool CanShoot()
    {
        if (CurrCooldown <= 0)
            return true;
        return false;
    }

    void SearchTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Warrior"))
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if (currDistance < nearestEnemyDistance && currDistance <= range)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = currDistance;
            }
        }

        if (nearestEnemy != null)
        {
            StartCoroutine(Shoot(nearestEnemy, 2));
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    IEnumerator Shoot(Transform enemy, float time)
    {
        anim.SetBool("isAttack", true);

        CurrCooldown = Cooldown;

        yield return new WaitForSeconds(time / 2);
        if (gameObject.GetComponent<HpScript>().currHP > 0)
        {
            GameObject proj = Instantiate(Projectile);
            proj.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
            proj.GetComponent<TowerProjectileScript>().SetTarget(enemy);
        }
        yield break;
    }

    void Update()
    {
        if (gameObject.GetComponent<HpScript>().currHP > 0)
        {
            if (CanShoot())
                SearchTarget();

            if (CurrCooldown > 0)
                CurrCooldown -= Time.deltaTime;
        }
    }
}
