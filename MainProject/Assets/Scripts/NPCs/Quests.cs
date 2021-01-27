using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    // 0 : Chief Rabby , 1 : planata Queen
    GameObject[] NPCs = new GameObject[4];
    public bool isPerfect;
    public float percentage = 0.0f;
   
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeetChief()
    {
        
    }


   public float PickPercentage
    {
        get {return percentage; }
        set
        {
            percentage = value;
 
            if(percentage >=1.0f)
            {
                percentage = 1.0f;
                isPerfect = true;
            }
        }
    }

}
