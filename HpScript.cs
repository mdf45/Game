using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    public float HP = 100;
    public float currHP;

    public bool isDead = false;

    public Animator anim;

    public GameObject HpBar;
    void Start()
    {
        currHP = HP;
        anim = GetComponent<Animator>();
        HpBar.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warrior")
        {
            HpBar.SetActive(true);
        }
    }

    void Update()
    {
        if (currHP <= 0)
        {
            isDead = true;
            Dead();
        }
    }
    void Dead()
    {
        StartCoroutine(Die(1f));
    }
    public void Animation()
    {
        HpBar.GetComponent<HpBarScript>().StopAllCoroutines();
        if (HpBar.GetComponent<HpBarScript>().redBar.transform.localScale.x != HpBar.GetComponent<HpBarScript>().yellowBar.transform.localScale.x)
        {
            HpBar.GetComponent<HpBarScript>().StartCoroutine(HpBar.GetComponent<HpBarScript>().wait());
        }
    }
    IEnumerator Die(float time)
    {
        anim.SetBool("isDead", true);
        
        yield return new WaitForSeconds(time);
        TakeBonus();
        gameObject.SetActive(false);
        yield break;
    }

    void TakeBonus()
    {
        MainScript.Gold += gameObject.GetComponent<BonusScript>().Gold;
        MainScript.Food += gameObject.GetComponent<BonusScript>().Food;
    }
}
