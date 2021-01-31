using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CogPuzzle : MonoBehaviour
{
    public GameObject button;
    public int[] num = new int[4] { 0, 1, 2, 3 };
    public int index = -1;



    void Start()
    {
        SwapIndex();
    }

    void Update()
    {
        MoveCogs();


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
                    _childPos += Vector3.right;
                }

            }
            
            if (_childPos.x > -6)
            {
                if (Input.GetButtonDown("360_X_Button"))
                {
                    _childPos += Vector3.left;
                }
            }

            if (_childPos.y < 7)
            {
                if (Input.GetButtonDown("360_Y_Button"))
                {
                    _childPos += Vector3.up;
                }
            }
            
            if(_childPos.y > 3)
            {
                if(Input.GetButtonDown("360_A_Button"))
                {
                    _childPos += Vector3.down;
                }
            }

            transform.GetChild(num[index]).position = _childPos;
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

