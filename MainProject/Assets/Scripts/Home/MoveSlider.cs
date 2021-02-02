using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlider : MonoBehaviour
{
    public OpenSprite openSprite;

    [Space]
    public GameObject fireNpc;

    [Space]
    public GameObject effect;
    public Transform effectPt;

    [Space]
    public float speed = 1f;

    float left = 0.94f;
    float right = 1.635f;

    bool isLeft = false;
    bool isOn = false;

    int clearCount = 3;

    private void OnTriggerEnter2D(Collider2D collision) => isOn = true;

    private void OnTriggerExit2D(Collider2D collision) => isOn = false;

    void init()
    {
        isLeft = false;
        isOn = false;

        clearCount = 3;
        speed = 1f;

        Vector3 _pos = transform.position;
        _pos.x = left;
        transform.position = _pos;
    }

    private void Update()
    {
        if(openSprite.isIn == false && isOn == false) init();

        ChangeDirection();

        ButtonDown();
    }

    void ChangeDirection()
    {
        if (!isLeft)
        {
            if (transform.position.x < right) transform.Translate(Vector3.right * Time.deltaTime * speed);

            else isLeft = true;
        }
        else
        {
            if (transform.position.x > left) transform.Translate(Vector3.left * Time.deltaTime * speed);

            else isLeft = false;
        }
    }

    void ButtonDown()
    {
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
        HomeQuest.instance.ClearQuest(0);
        fireNpc.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        PlayerController.isMatchItem = false;
    }
}
