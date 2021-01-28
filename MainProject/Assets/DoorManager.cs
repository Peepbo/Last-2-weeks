using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{


    [Space]
    public GameObject buttonHead;
    Animator btnAnim;

    private void Awake()
    {
        btnAnim = buttonHead.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player")) buttonHead.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player")) btnAnim.SetTrigger("Out");
    }
}
