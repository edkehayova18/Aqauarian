using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownHandler : MonoBehaviour
{
    public Dropdown dropdown;
    public static int chosenDifficulty;
    public static bool isHardcore;

    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        if (toggle.isOn)
        {
            isHardcore = true;
        }
        else
        {
            isHardcore = false;
        }
    }

    void Update()
    {
        chosenDifficulty = dropdown.value;
    }
}