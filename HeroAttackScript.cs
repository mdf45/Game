using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackScript : MonoBehaviour
{
    public int Damage = 35;
    private float CurrCooldown;
    public float Cooldown;
    public bool isObj = false;

    public GameObject obj;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            CurrCooldown = Cooldown;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Attack();
            if (gameObject.transform.position.y > obj.transform.position.y)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

                obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
        }
    }
    void Update()
    {
        if (CurrCooldown > 0)
            CurrCooldown -= Time.deltaTime;
        if (isObj)
        {
            if (!obj.activeSelf)
            {
                isObj = false;
                GetComponent<Move>().SearchEnemy();
            }
        }
        Debug.Log(obj);
    }

    public void Attack()
    {
        if (CurrCooldown <= 0)
        {
            obj.GetComponent<HpScript>().currHP -= Damage;
            obj.GetComponent<HpScript>().Animation();
            CurrCooldown = Cooldown;
        }
    }
}
