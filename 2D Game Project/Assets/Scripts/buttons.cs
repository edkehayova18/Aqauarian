using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public static int checkpoint = 2;

    public void playAgain()
    {
        SceneManager.LoadScene(checkpoint);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }   

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}