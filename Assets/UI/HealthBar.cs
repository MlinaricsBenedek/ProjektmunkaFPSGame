using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void MaxValueSet(int hp){  //maxon kezdjen a slider
        //slider.maxValue = hp;
        slider.value = hp;
    }
    public void ValueSet(int hp){
        slider.value = hp;
    }
}
