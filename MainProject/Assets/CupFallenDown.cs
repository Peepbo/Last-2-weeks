using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupFallenDown : MonoBehaviour
{
    public GameObject cylinder;
    public GameObject effect;
    public GameObject fire;
    public GameObject Slider;
    public GameObject Match;

    public GameObject Cup0;

    public GameObject Cup1;
    //public GameObject RaiseQuest;

    Animator anim;

    bool onTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !onTime)
        {
            anim.SetTrigger("Fall");
            onTime = true;
        }
    }

    public void EffectOn()
    {
        cylinder.SetActive(false);
        effect.SetActive(true);
    }

    public void FireOff()
    {
        fire.SetActive(false);
    }

    public void SliderOn()
    {
        Slider.SetActive(true);
        Match.GetComponent<GetItem>().enabled = true;
        Match.GetComponent<Outline>().enabled = true;
        Cup0.SetActive(false);
        anim.enabled = false;
        transform.rotation = Quaternion.identity;
        Cup1.SetActive(true);
        //RaiseQuest.SetActive(true);

    }
}
