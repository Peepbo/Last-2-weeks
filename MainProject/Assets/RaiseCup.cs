using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseCup : MonoBehaviour
{
    public GameObject outlineCup;
    public GameObject areaButton;

    public GameObject fallenCup;
    bool isIn;
    bool isClear;

    private void Start()
    {
        areaButton.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            outlineCup.SetActive(true);
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            outlineCup.SetActive(false);
            isIn = false;
        }
    }

    private void Update()
    {
        if (!isClear)
        {
            if (fallenCup.transform.rotation.x < 0)
                fallenCup.transform.Rotate(Vector3.right * (50f *
                    -fallenCup.transform.rotation.x) * Time.deltaTime);

            if (isIn)
            {
                if (Input.GetButtonDown("360_X_Button"))
                {
                    fallenCup.transform.Rotate(Vector3.left * 10);
                }
            }

            if (fallenCup.transform.rotation.x < -0.7f)
            {
                isClear = true;
                HomeQuest.instance.ClearQuest(1);

                outlineCup.SetActive(false);
                areaButton.SetActive(false);
            }
        }
    }
}
