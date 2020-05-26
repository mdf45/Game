using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarScript : MonoBehaviour
{
    public GameObject obj;
    public GameObject redBar;
    public GameObject yellowBar;

    void Start()
    {
        
    }

    void Update()
    {
        if (obj.GetComponent<HpScript>().currHP >= 0)
        {
            redBar.transform.localScale = new Vector3(obj.GetComponent<HpScript>().currHP / obj.GetComponent<HpScript>().HP, 1, 1);
        }
        else
            redBar.transform.localScale = new Vector3(0, 1, 1);
        if (yellowBar.transform.localScale.x <= 0)
        {
            yellowBar.transform.localScale = new Vector3(0, 1, 1);
            isDead();
        }
    }

    
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(an());
        yield break;
    }
    IEnumerator an()
    {
        while (yellowBar.transform.localScale.x > redBar.transform.localScale.x)
        {
            yield return new WaitForSeconds(0.01f);
            yellowBar.transform.localScale = new Vector3(yellowBar.transform.localScale.x - 0.01f, 1, 1);
        }
        yield break;
    }
    public void isDead()
    {
        StartCoroutine(Dead(1f));
    }

    IEnumerator Dead(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        yield break;
    }
}
