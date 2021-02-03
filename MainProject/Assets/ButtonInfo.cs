using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    Image img;

    public Color myColor
    {
        get 
        {
            if (img == null) img = GetComponent<Image>();

            return img.color; 
        }

        set
        {
            if (img == null) img = GetComponent<Image>();

            img.color = value;
        }
    }

    private void Awake()
    {
        img = GetComponent<Image>();
    }
}
