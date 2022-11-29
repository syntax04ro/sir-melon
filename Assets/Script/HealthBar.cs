using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;

    public void MaxHealth(float health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }
    
    public void setHealth(float health)
    {
        hpSlider.value = health;
    }
}
