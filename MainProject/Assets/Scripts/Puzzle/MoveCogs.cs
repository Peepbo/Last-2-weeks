using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCogs : MonoBehaviour
{
  
    public GameObject cog;
    bool isReady = false;
    private Vector3 currentPos; 
   
    void Start()
    {
        
    }


    void Update()
    {


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Player"))
        {
            isReady = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag.Equals("Player"))
        {
            isReady = false;
        }
    }

}
