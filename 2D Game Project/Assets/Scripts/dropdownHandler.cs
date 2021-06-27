using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownHandler : MonoBehaviour
{
    List<string> names = new List<string>() { "Easy", "Normal", "Hard" };

    public Dropdown dropdownObject;
    public static int minusOxygen;

    public static bool hardcore;

    public void DropDown_IndexChanged(int index)
    {
        minusOxygen = index;
    }
}