using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeQuest : MonoBehaviour
{
    public static HomeQuest instance;

    public MoveSlider moveSlider;
    public OpenSprite openSprite;
    public TimeLimit timeLimit;

    bool bonfireQuest = false;
    bool raiseCup = false;

    private void Awake() { instance = this; }

    public void Clear() 
    { 
        bonfireQuest = true;
        openSprite.gameObject.SetActive(false);
        timeLimit.gameObject.SetActive(false);
    }

    public void ClearQuest(int index)
    {
        if(index == 0) bonfireQuest = true;

        else raiseCup = true;

        if (bonfireQuest && raiseCup) Clear();
    }
}
