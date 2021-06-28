using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : MonoBehaviour
{
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;
    public GameObject orangeBarrier1;
    public GameObject redDie;
    public GameObject grayDrown;

    private bool[] buttonPushed = new bool[7] { true, true, false, false, true, false, true };
    private bool waitTimer = false;

    void Update()
    {
        barrier1.SetActive(buttonPushed[0]);
        barrier2.SetActive(buttonPushed[1]);
        barrier3.SetActive(buttonPushed[2]);
        barrier4.SetActive(buttonPushed[3]);
        redDie.SetActive(buttonPushed[4]);
        grayDrown.SetActive(buttonPushed[5]);
        orangeBarrier1.SetActive(buttonPushed[6]);
    }

    public void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "yellow" && !waitTimer)
        {
            for (int i = 0; i < 6; i++)
            {
                buttonPushed[i] = !buttonPushed[i];
            }
            StartCoroutine(wait());
        }

        if (Player.gameObject.tag == "orange" && !waitTimer)
        {
            buttonPushed[6] = !buttonPushed[6];
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        waitTimer = true;
        yield return new WaitForSeconds(1);
        waitTimer = false;
    }
}