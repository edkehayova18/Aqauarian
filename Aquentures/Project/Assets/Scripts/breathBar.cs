using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breathBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxBreath(int breath)
    {
        slider.maxValue = breath;
        slider.value = breath;
    }

    public void setBreath(int breath)
    {
        slider.value = breath;
    }
}
