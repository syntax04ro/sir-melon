using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBoss : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient grad;
    public Image fill;
    public void MaxHealth(float health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
        fill.color = grad.Evaluate(1f);
    }
    
    public void setHealth(float health)
    {
        hpSlider.value = health;
        fill.color = grad.Evaluate(hpSlider.normalizedValue);
    }
}
