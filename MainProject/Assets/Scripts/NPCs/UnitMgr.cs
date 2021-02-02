using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMgr : MonoBehaviour
{
    public bool isTalk = false;
    protected bool isCol = false;
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
        if (other.CompareTag("Player"))
        {
            isCol = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isCol = false;
    }

    public Vector3 GetRandomDirection(bool isXDir = false, bool isYDir = false, bool isZDir = false)
    {
        Vector3 _a = new Vector3(0, 0, 0);
        int _rnd;

        if (isXDir)
        {
            _rnd = Random.Range(-1, 2);
            _a.x += _rnd;
        }

        return _a;
    }
}
