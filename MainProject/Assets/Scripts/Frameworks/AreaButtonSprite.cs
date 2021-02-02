using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AreaButtonSprite : MonoBehaviour
{
    GameObject spriteObj;
    Animator anim;

    Action[] action = new Action[2];

    public bool isOn = false;

    private void Awake()
    {
        spriteObj = transform.GetChild(0).gameObject;
        anim = spriteObj.GetComponent<Animator>();

        action[0] = () => { spriteObj.SetActive(true); isOn = true; };
        action[1] = () => { anim.SetTrigger("Out"); isOn = false; };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) action[0]();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) action[1]();
    }
}
