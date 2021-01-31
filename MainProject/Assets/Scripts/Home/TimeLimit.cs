using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void Update()
    {
        if(slider.value < 1) slider.value += 0.0001f;
    }
}
