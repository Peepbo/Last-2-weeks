using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : MonoBehaviour
{
    float nutrition = 0.0f;
    public Quests mushQuest;

   
    void Start()
    {
        nutrition = Random.Range(0.2f, 5.0f);
        int size = (int)(nutrition * 10.0f);
        transform.localScale = new Vector3(size, size, size);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag.Equals("Player") &&
            Input.GetButtonDown("360_X_Button"))
        {
            mushQuest.PickPercentage += nutrition;

            gameObject.SetActive(false);
        }

    }
}


