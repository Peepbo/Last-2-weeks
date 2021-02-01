using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Transform camPos;
    BoxCollider[] collider = new BoxCollider[2];
    bool isIn;
    bool isActive;

    private void Awake()
    {
        collider = GetComponents<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isIn = false;
    }

    private void Update()
    {
        if(isIn)
        {
            if(Input.GetButtonDown("360_X_Button"))
            {
                isActive = true;
                for (int i = 0; i < 2; i++) collider[i].enabled = false;
            }
        }

        if(isActive)
        {
            transform.position = Vector3.Lerp(transform.position, camPos.position, Time.deltaTime * 2.5f);
            transform.Rotate(Vector3.down * Time.deltaTime  * 80f);
            transform.Rotate(Vector3.back * Time.deltaTime  * 5f);
        }
    }
}
