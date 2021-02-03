using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BtnPuzzle : MonoBehaviour
{
    public bool[,] isActive = new bool[3, 3];
    public Image[,] btn = new Image[3, 3];
    public int index = -1;
    public int count = 0;
    public bool isClear = false;

    public GameObject panel;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                //Debug.Log(j + i * 3);
                btn[i, j] = transform.GetChild(j + i * 3).GetComponent<Image>();
            }
        }
    }


    void Update()
    {
        if (count == 9)
        {
            isClear = true;
            panel.SetActive(true);
            PlayerPrefs.SetString("ButtonPuzzle", "clear");
            count = 0;
            SceneManager.LoadScene("StartScene");
        }
    }

    public void SendMyNumber(int clickNumber)
    {
        if (isClear) return;
        //0~8
        index = clickNumber;

        //8 = (2,2)
        int x = index % 3; // 1
        int y = index / 3; // 1

        if (!isActive[y, x])
        {
            isActive[y, x] = true;
            btn[y, x].color = Color.red;
            count++;
        }
        else
        {
            isActive[y, x] = false;
            btn[y, x].color = Color.white;
            count--;
        }
        //위,왼,오른,아래

        //위

        if (y != 0)
        {

            if (!isActive[y - 1, x])
            {
                isActive[y - 1, x] = true;
                btn[y - 1, x].color = Color.red;
                count++;
            }
            else
            {
                isActive[y - 1, x] = false;
                btn[y - 1, x].color = Color.white;
                count--;
            }
        }

        //아래
        if (y != 2)
        {
            if (!isActive[y + 1, x])
            {
                isActive[y + 1, x] = true;
                btn[y + 1, x].color = Color.red;
                count++;
            }
            else
            {
                isActive[y + 1, x] = false;
                btn[y + 1, x].color = Color.white;
                count--;
            }
        }

        //왼쪽
        if (x != 0)
        {
            if (!isActive[y, x - 1])
            {
                isActive[y, x - 1] = true;
                btn[y, x - 1].color = Color.red;
                count++;
            }
            else
            {
                isActive[y, x - 1] = false;
                btn[y, x - 1].color = Color.white;
                count--;
            }
        }

        //오른쪽
        if (x != 2)
        {
            if (!isActive[y, x + 1])
            {
                isActive[y, x + 1] = true;
                btn[y, x + 1].color = Color.red;
                count++;
            }
            else
            {
                isActive[y, x + 1] = false;
                btn[y, x + 1].color = Color.white;
                count--;
            }

        }


    }
}
