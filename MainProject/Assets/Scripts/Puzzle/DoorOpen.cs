using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Transform startPos;
    Transform endPos;

    void Start()
    {
        startPos = transform.GetChild(0).GetComponent<Transform>();
        endPos = transform.GetChild(0).GetChild(0).GetComponent<Transform>();
    }

    void Update()
    {

    }

    IEnumerator FloatObject()
    {
        while (true)
        {

            yield return null;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name.Equals("FatherPlayer"))
        {
            transform.position = endPos.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Equals("FatherPlayer"))
        {
            transform.position = startPos.position;
        }

    }
}
