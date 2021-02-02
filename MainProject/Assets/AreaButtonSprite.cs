using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaButtonSprite : MonoBehaviour
{
    public GameObject buttonSprite;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            buttonSprite.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
            buttonSprite.GetComponent<Animator>().SetTrigger("Out");
    }
}
