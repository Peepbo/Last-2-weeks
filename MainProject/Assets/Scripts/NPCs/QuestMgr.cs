using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMgr : MonoBehaviour
{
    public enum QUESTTYPE
    {
       START,GREET,FEED_MUSH, FIND_BABY
    }

    public QUESTTYPE currentQuest;

    void Start()
    {
       
    }


    void Update()
    {
        switch (currentQuest)
        {
            case QUESTTYPE.START:
                break;
            case QUESTTYPE.GREET:
                break;
            case QUESTTYPE.FEED_MUSH:
                Debug.Log("open hidden room");
                break;
            case QUESTTYPE.FIND_BABY:
                break;
            default:
                break;
        }
    }
}
