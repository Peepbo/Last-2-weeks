using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
    bool isTalk=false;


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            isTalk = true;
            Debug.Log("안녕 플레이어?");
        }
    }
}
