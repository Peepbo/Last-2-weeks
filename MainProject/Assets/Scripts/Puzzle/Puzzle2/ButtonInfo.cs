using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ButtonInfo : MonoBehaviour
{
    int idx;
    Image img;
    Action btnAct;
    

    public Color myColor
    {
        get 
        {
            return img.color; 
        }

        set
        {
            img.color = value;
        }
    }

    public Action setAct
    {
        set
        {
            btnAct = value;
            GetComponent<Button>().onClick.AddListener(() => btnAct());
        }
    }

    public int myIndex
    {
        get
        {
            return idx;
        }

        set
        {
            idx = value;
        }
    }

    private void Awake()
    {
        img = GetComponent<Image>();
    }
}
