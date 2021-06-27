using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2 : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    private bool[] buttonsPush = new bool[4] { false, false, false, false };
    private bool[] waitTimer = new bool[4] { false, false, false, false };

    void Update()
    {
        button1.SetActive(buttonsPush[0]);
        button2.SetActive(buttonsPush[1]);
        button3.SetActive(buttonsPush[2]);
        button4.SetActive(buttonsPush[3]);
    }

    public void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "button1" && !waitTimer[0])
        {
            buttonsPush[0] = true;
            buttonsPush[3] = false;
            StartCoroutine(wait(0));
        }
        if (Player.gameObject.tag == "button2" && !waitTimer[1])
        {
            buttonsPush[3] = true;
            buttonsPush[1] = false;
            StartCoroutine(wait(1));
        }
        if (Player.gameObject.tag == "button3" && !waitTimer[2])
        {
            buttonsPush[1] = true;
            StartCoroutine(wait(2));
        }
        if (Player.gameObject.tag == "button4" && !waitTimer[3])
        {
            buttonsPush[2] = true;
            buttonsPush[1] = false;
            StartCoroutine(wait(3));
        }
    }

    IEnumerator wait(int index)
    {
        waitTimer[index] = true;
        yield return new WaitForSeconds(1);
        waitTimer[index] = false;
    }
}