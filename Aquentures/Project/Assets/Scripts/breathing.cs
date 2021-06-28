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

    public int maxBreath = 15 - dropdownHandler.chosenDifficulty;
    public int currentBreath;

    private bool breatheFlag;
    private bool[] flag = new bool[3] { false, false, false };

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

        if (Player.gameObject.tag == "pressure plate" || Player.gameObject.tag == "pressure plate 2" || Player.gameObject.tag == "pressure plate 3")
        {
            if (flag[0] == true)
            {
                SceneManager.LoadScene("Level " + 2);
                flag[0] = false;
            }
            else if (flag[1] == true)
            {
                SceneManager.LoadScene("Level " + 4);
                flag[1] = false;
            }
            else if (flag[2] == true)
            {
                SceneManager.LoadScene("Credits");
                flag[2] = false;
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
            flag[0] = true;
        }
        if (Player.gameObject.tag == "pressure plate 2")
        {
            flag[1] = true;
        }
        if (Player.gameObject.tag == "pressure plate 3")
        {
            flag[2] = true;
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
            currentBreath+=3;
        }
        StartCoroutine(drown());
    }
}