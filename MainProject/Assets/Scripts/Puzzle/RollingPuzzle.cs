using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public class RollingPuzzle : MonoBehaviour
{
    public GameObject[] objs;
    public Text txt;
    private Image[] firstLineImgs;
    private Image[] secondLineImgs;
    public int[] arr = new int[4] { 2, 1, 0, 1 };
    public int[] firstLine = new int[4] { 0, 0, 0, 1 };
    public int[] secondLine = new int[4] { 1, 1, 0, 1 };

    public bool isClear;

    private void Awake()
    {
        firstLineImgs = objs[0].GetComponentsInChildren<Image>();
        secondLineImgs = objs[1].GetComponentsInChildren<Image>();

    }


    private void Start()
    {
        ChangeColor();
        txt.text = "";
        for (int i = 0; i < 4; i++)
        {
            txt.text += arr[i].ToString();
        }
    }


    void Update()
    {

        if (!isClear)
        {
            ChangeColor();

            ClearCheck();
        }
        else
        {
            txt.text = "Clear";
        }

    }



    public void LeftButton(int index)
    {

        int[] line;

        if (index == 0)
        {
            line = firstLine;
        }
        else
        {
            line = secondLine;
        }


        int _temp = 0;

        for (int i = 0; i < 4; i++)
        {

            if (i == 0)
            {
                _temp = line[0];
            }

            if (i == 3)
            {
                line[i] = _temp;
            }

            else
            {

                line[i] = line[i + 1];
            }
        }
    }


    public void RightButton(int index)
    {
        int[] line;

        if (index == 0)
        {
            line = firstLine;
        }
        else
        {
            line = secondLine;
        }

        int _temp = 0;
        for (int i = 3; i >= 0; i--)
        {
            if (i == 3)
            {
                _temp = line[3];
            }

            if (i == 0)
            {
                line[i] = _temp;
            }
            else
            {

                line[i] = line[i - 1];
            }

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
            else break;

        }

        if (_count == 4) isClear = true;
    }


    public void ChangeColor()
    {
        for (int i = 0; i < 4; i++)
        {
            if (firstLine[i] == 0) firstLineImgs[i].color = Color.white;
            else firstLineImgs[i].color = Color.blue;

            if (secondLine[i] == 0) secondLineImgs[i].color = Color.white;
            else secondLineImgs[i].color = Color.blue;

        }
    }
}
