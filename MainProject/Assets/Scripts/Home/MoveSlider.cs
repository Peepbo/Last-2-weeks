using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlider : MonoBehaviour
{
    public OpenSprite openSprite;
    [Space]
    public GameObject fireNpc;
    public GameObject effect;
    public Transform effectPt;

    public float speed = 1f;

    public bool isClear = false;

    float left = 0.94f;
    float right = 1.635f;

    bool isLeft = false;
    bool isOn = false;

    int clearCount = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOn = false;
    }

    private void Update()
    {
        if(openSprite.isIn == false)
        {
            openSprite.lightTiming.SetActive(false);
            clearCount = 3;
            isLeft = false;
            isOn = false;
            Vector3 _samplePos = transform.position;
            _samplePos.x = left;
            transform.position = _samplePos;
            speed = 1f;
        }
        //

        if(!isLeft)
        {
            if(transform.position.x < right) transform.Translate(Vector3.right * Time.deltaTime * speed);

            else isLeft = true;
        }
        else
        {
            if (transform.position.x > left) transform.Translate(Vector3.left * Time.deltaTime * speed);

            else isLeft = false;
        }

        if (clearCount > 0 && isOn && Input.GetButtonDown("360_B_Button"))
        {
            clearCount--;
            speed *= 1.15f;

            Instantiate(effect, effectPt.position, Quaternion.identity);

            if (clearCount == 0) EndPuzzle();
        }
    }

    void EndPuzzle()
    {
        isClear = true;
        HomeQuest.instance.ClearQuest(0);
        fireNpc.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        PlayerController.isMatchItem = false;
    }
}
