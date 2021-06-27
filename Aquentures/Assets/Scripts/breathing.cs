using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class breathing : MonoBehaviour
{
    public breathBar breathScript;
    public buttons buttonsScript;

    public GameObject platform;

    public int maxBreath = 15 - dropdownHandler.minusOxygen;
    public int currentBreath;

    private bool breatheFlag;
    private bool flag = false;

    void Start()
    {
        currentBreath = maxBreath;
        breathScript.setMaxBreath(maxBreath);
        StartCoroutine(drown());
    }

    void Update()
    {
        breathScript.setBreath(currentBreath);

        if (currentBreath <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonsScript.playAgain();
        }
    }

    public void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "canBreathe")
        {
            breatheFlag = true;
        }
        if (Player.gameObject.tag == "die")
        {
            currentBreath = 0;
        }
        if (Player.gameObject.tag == "pressure plate")
        {
            if (flag == true)
            {
                SceneManager.LoadScene("Level " + 2);
                flag = false;
                buttons.checkpoint--;
            }
            else
            {
                SceneManager.LoadScene("Level " + (buttons.checkpoint - 1));
                buttons.checkpoint++;
            }
        }
        if (Player.gameObject.tag == "spawnPlatform")
        {
            platform.SetActive(true);
            flag = true;
        }
    }

    public void OnCollisionExit2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "canBreathe")
        {
            breatheFlag = false;
        }
    }

    IEnumerator drown()
    {
        yield return new WaitForSeconds(1);
        if (!breatheFlag && currentBreath > 0)
        {
            currentBreath--;
        }
        else if (breatheFlag && currentBreath < maxBreath)
        {
            currentBreath++;
        }
        StartCoroutine(drown());
    }
}