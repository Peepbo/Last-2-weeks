using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CogPuzzle : MonoBehaviour
{
    public GameObject button;
    public GameObject finalCog;
    public int[] num = new int[4] { 0, 1, 2, 3 };
    public int index = -1;
    private int cnt = 0;
    private float speed = 1.5f;

    void Start()
    {
        SwapIndex();
    }

    void Update()
    {
        MoveCogs();

        if (cnt == 4)
        {
            Vector3 _mainCog = finalCog.transform.position;

            if (_mainCog.x > 0)
            {
                _mainCog.x -= speed * Time.deltaTime;
                finalCog.transform.position = _mainCog;
            }
        }
    }

    void MoveCogs()
    {
        if (index != -1)
        {
            Vector3 _childPos = transform.GetChild(num[index]).position;
            //  num 2 0 1 3 
            //index 1     num[index] =0
            if (_childPos.x < 6)
            {
                if (Input.GetButtonDown("360_B_Button"))
                {
                    SetPos(Vector3.right);
                }

            }

            if (_childPos.x > -6)
            {
                if (Input.GetButtonDown("360_X_Button"))
                {
                    SetPos(Vector3.left);
                }
            }

            if (_childPos.y < 7)
            {
                if (Input.GetButtonDown("360_Y_Button"))
                {
                    SetPos(Vector3.up);

                }
            }

            if (_childPos.y > 3)
            {
                if (Input.GetButtonDown("360_A_Button"))
                {
                   SetPos(Vector3.down);
                }
            }
        }
    }

    //주소
    private void SetPos(Vector3 movePos)
    {
        transform.GetChild(num[index]).position += movePos;
        CheckClear();
    }

    public void CheckClear()
    {
        if (index != -1)
        {
            int _count = transform.childCount;

            cnt = 0;
            for (int i = 0; i < _count; i++)
            {
                if (transform.GetChild(i).position.x == 0 &&
                    transform.GetChild(i).position.y == 6)
                {
                    cnt++;
                    //여기에 브레이크가 있어서 하나만 더해지고 for문을 나가버림
                }
            }

        }
    }

    [ContextMenu("mix")]
    void SwapIndex()
    {
        int _dest = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int _ran = Random.Range(0, num.Length);

            _dest = num[_ran];
            num[_ran] = num[i];
            num[i] = _dest;
        }

    }


}

