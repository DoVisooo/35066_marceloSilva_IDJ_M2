using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxAbility(int ability)
    {
        slider.maxValue = ability;
        slider.value = ability;
    }

    public void SetAbility(int ability)
    {
        slider.value = ability;
    }
}
