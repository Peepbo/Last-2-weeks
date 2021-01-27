using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    public static ChoosePlayer instance;

    public int order = 0;
    bool isChange = false;

    private void Awake()
    {
        instance = this;
    }


    public void ChangeOrder()
    {
        if (isChange) return;

        if (order == 0) order = 1;
        else order = 0;

        instance.StartCoroutine(SetDelay());
    }

    IEnumerator SetDelay()
    {
        isChange = true;
        yield return new WaitForSeconds(1.5f);
        isChange = false;
    }
}
