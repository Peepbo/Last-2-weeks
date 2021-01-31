using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public string nextSceneName;
    [Space]
    public GameObject buttonHead;
    Animator btnAnim;

    bool isIn;

    private void Awake()
    {
        btnAnim = buttonHead.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            buttonHead.SetActive(true);
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            btnAnim.SetTrigger("Out");
            isIn = false;
        }
    }

    private void Update()
    {
        if(isIn && Input.GetButtonDown("360_X_Button"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
