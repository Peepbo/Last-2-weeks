using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Transform camPos;
    public Transform playerPos;

    public GameObject buttonHead;

    BoxCollider[] collider = new BoxCollider[2];
    Outline outline;
    bool isIn;
    bool isActive;
    bool isGet;
    bool isDrop;

    private void Awake()
    {
        collider = GetComponents<BoxCollider>();
        outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enabled == false) return;

        if (other.CompareTag("Player"))
        {
            buttonHead.SetActive(true);
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enabled == false) return;

        if (other.CompareTag("Player"))
        {
            buttonHead.GetComponent<Animator>().SetTrigger("Out");
            isIn = false;
        }
    }

    private void Update()
    {
        if(isDrop) return;

        if(isIn && !isActive)
        {
            if(Input.GetButtonDown("360_X_Button"))
            {
                isActive = true;
                for (int i = 0; i < 2; i++) collider[i].enabled = false;
                buttonHead.SetActive(false);

                StartCoroutine(DelayPos());
            }
        }

        if(isGet)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos.position, Time.deltaTime * 7f);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerPos.rotation, Time.deltaTime * 3f);

            if(Vector3.Distance(transform.position, playerPos.position) < 0.1f)
            {
                transform.parent = playerPos;

                if(PlayerController.isMatchItem == false)
                {
                    isGet = false;
                    isActive = false;

                    collider[0].enabled = true;
                    transform.parent = null;
                    Rigidbody _rigid = gameObject.AddComponent<Rigidbody>();
                    _rigid.mass = 3f;
                    _rigid.AddForce(Vector3.up * 100f);
                    isDrop = true;
                }
            }
        }

        else if(isActive)
        {
            transform.position = Vector3.Lerp(transform.position, camPos.position, Time.deltaTime * 2.5f);
            transform.Rotate(Vector3.back * Time.deltaTime  * 75f);
        }
    }

    IEnumerator DelayPos()
    {
        yield return new WaitForSeconds(1.75f);
        isGet = true;

        PlayerController.isMatchItem = true;
        outline.enabled = false;
    }
}
