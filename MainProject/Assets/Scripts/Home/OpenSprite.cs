using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;


public class OpenSprite : MonoBehaviour
{
    public  GameObject lightTiming;
    public  GameObject buttonSprite;
    private Action     deActiveAct;
    private Action     ActiveAct;
    public  bool       isIn;

    private void Awake()
    {
        ActiveAct = () =>
        {
            buttonSprite.SetActive(true);
            isIn = true;
        };

        deActiveAct = () =>
        {
            if (lightTiming.activeSelf) lightTiming.SetActive(false);

            buttonSprite.GetComponent<Animator>().SetTrigger("Out");
            isIn = false;
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ActiveAct();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) deActiveAct();
    }

    private void Update()
    {
        if(isIn)
        {
            if (Input.GetButtonDown("360_X_Button"))
            {
                lightTiming.SetActive(true);
                buttonSprite.SetActive(false);
            }
        }
    }
}
