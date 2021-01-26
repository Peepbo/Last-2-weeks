using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMgr : MonoBehaviour
{
    public bool isTalk = false;
    protected bool isStare = false;
    protected GameObject target;
    protected Vector3 direction;
    protected Quaternion startRotation;


    protected virtual void Awake()
    {
        startRotation = transform.rotation;
        target = GameObject.FindWithTag("Player");
    }

    void Start()
    {

    }

    protected virtual void Update()
    {
        if (isStare)
        {
            Stare();
        }
        else transform.rotation = startRotation;

    }

    protected virtual void Stare()
    {
        direction = (target.transform.position - transform.position).normalized;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }

    protected virtual void Talk()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            isStare = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            isStare = false;
    }

}
