using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Slider slider;
    public float cdrStart = 0f;
    public float cdr = 3f;

    void Start()
    {
        slider.maxValue = cdrStart;
    }

    public void SetDashCooldown(float cdr)
    {
        slider.value = Time.time + cdr;
    }
}
