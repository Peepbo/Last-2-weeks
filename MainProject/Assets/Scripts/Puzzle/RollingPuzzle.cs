using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class RollingPuzzle : MonoBehaviour
{
    int[] arr = new int[4] { 2, 1, 0, 1 };
    int[] firstLine = new int[4] { 1, 1, 0, 0 };
    int[] secondLine = new int[4] { 1, 1, 0, 1 };

    bool isClear;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isClear)
        {
            FirstLineLeft();
            FirstLineRight();
            ClearCheck();
        }
      

    }



    public void FirstLineLeft()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int _temp = 0;
            for (int i = 0; i < 4; i++)
            {

                if (i == 0)
                {
                    _temp = firstLine[0];
                }

                if (i == 3)
                {
                    firstLine[i] = _temp;
                }

                else
                {

                    firstLine[i] = firstLine[i + 1];
                }

                Debug.Log(i + " : " + firstLine[i]);

            }
            ClearCheck();
        }
    }


    public void FirstLineRight()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int _temp = 0;
            for (int i = 4; i < 0; i--)
            {

                if (i == 3)
                {
                    _temp = firstLine[3];
                }

                if (i == 0)
                {
                    firstLine[i] = _temp;
                }
                else
                {

                    firstLine[i] = firstLine[i - 1];
                }

                Debug.Log(i + " : " + firstLine[i]);


            }
            ClearCheck();
        }
    }

    public void ClearCheck()
    {
        int _count = 0;

        for (int i = 0; i < 4; i++)
        {
            if (firstLine[i] + secondLine[i] == arr[i])
            {
                _count++;

            }
           
        }

        if (_count == 4) isClear = true;
    }
}
