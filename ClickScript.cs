using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public GameObject g;
    public GameObject image;

    public static bool canClick = true;
    void Start()
    {
        //image.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MainScript.Warriors > 0 && canClick)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 3;
            /*if (pos.y < -2)
            {
                Instantiate(g, pos, transform.rotation);
            }
            else
            {
                image.SetActive(true);
                StartCoroutine(Wait(1.5f));
            }*/
            Instantiate(g, pos, transform.rotation);
            MainScript.Warriors -= 1;
            //Debug.LogWarning(pos);
        }
    }

    IEnumerator Wait(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);

        image.SetActive(false);
    }
}
