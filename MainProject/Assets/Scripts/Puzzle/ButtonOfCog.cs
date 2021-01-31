using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOfCog : MonoBehaviour
{
    public CogPuzzle temp;
    public int myIndex = 0;

    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            temp.index = myIndex;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            temp.index = -1;
        }
    }


}
