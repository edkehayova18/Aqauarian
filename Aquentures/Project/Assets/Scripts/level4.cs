using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4 : MonoBehaviour
{
    public GameObject yellowBarrier1;
    public GameObject yellowBarrier2;
    public GameObject orangeBarrier1;
    public GameObject orangeBarrier2;
    public GameObject orangeBarrier3;
    public GameObject orangeBarrier4;

    public GameObject redDie;
    public GameObject grayDrown;

    private bool[] buttonPushed = new bool[8] { true, true, true, false, false, true, true, false };
    private bool waitTimer = false;

    void Update()
    {
        yellowBarrier1.SetActive(buttonPushed[0]);
        yellowBarrier2.SetActive(buttonPushed[1]);
        orangeBarrier1.SetActive(buttonPushed[2]);
        orangeBarrier2.SetActive(buttonPushed[3]);
        orangeBarrier3.SetActive(buttonPushed[4]);
        orangeBarrier4.SetActive(buttonPushed[5]);
        redDie.SetActive(buttonPushed[6]);
        grayDrown.SetActive(buttonPushed[7]);
    }

    public void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "yellow" && !waitTimer)
        {
            for (int i = 0; i < 2; i++)
            {
                buttonPushed[i] = !buttonPushed[i];
            }
            StartCoroutine(wait());
        }

        if (Player.gameObject.tag == "orange" && !waitTimer)
        {
            for (int i = 2; i < 8; i++)
            {
                buttonPushed[i] = !buttonPushed[i];
            }
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