using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ButtonPuzzle2 : MonoBehaviour
{
    public GameObject endPuzzle;

    public List<GameObject> btn;

    public int[] index = { -1, -1 };
    public int pivot = 0;

    int maxPoint;
    public int point;

    private void Awake()
    {
        index[0] = index[1] = -1;

        GetObjs();

        SetColors();

        Suffle();
    }

    private void GetObjs()
    {
        GameObject[] obj = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            obj[i] = transform.GetChild(i).gameObject;

        for (int i = 0; i < obj.Length; i++)
        {
            for (int j = 0; j < obj[i].transform.childCount; j++)
            {
                obj[i].transform.GetChild(j).gameObject.AddComponent<ButtonInfo>();
                btn.Add(obj[i].transform.GetChild(j).gameObject);
            }
        }

        maxPoint = btn.Count / 2;
    }

    private void SetColors()
    {
        int a, b, c, d;

        //13
        a = btn.Count / 4 + 1;
        b = btn.Count / 4 + 3;
        c = btn.Count / 4 - 1;
        d = btn.Count / 4 - 1;

        int[] _counts = { a, b, c, d };
        Color[] _colors = { Color.red, Color.blue, Color.yellow, Color.green };

        //레드가 a개
        //블루가 b개
        //옐로가 c개
        //그린이 d개
        int _order = 0;
        int _colorOrder = 0;
        for (int i = 0; i < btn.Count; i++)
        {
            if (_order == _counts[_colorOrder])
            {
                _order = 1;
                _colorOrder++;
                if (_order == _counts[_colorOrder]) _colorOrder++;
            }
            else _order++;

            ButtonInfo _info = btn[i].GetComponent<ButtonInfo>();

            int local = i;

            _info.myColor = _colors[_colorOrder];
            _info.setAct = () => ClickBtn(local);
            _info.myIndex = local;
        }
    }

    [ContextMenu("Suffle")]
    public void Suffle()
    {
        //suffle
        int _idx = 0;
        Color _Color = btn[0].GetComponent<ButtonInfo>().myColor;
        for (int i = 0; i < btn.Count / 2; i++)
        {
            _idx = Random.Range(0, btn.Count);

            ButtonInfo _idxInfo = btn[_idx].GetComponent<ButtonInfo>();
            ButtonInfo _iInfo = btn[i].GetComponent<ButtonInfo>();

            _Color = _idxInfo.myColor;

            _idxInfo.myColor = _iInfo.myColor;
            _iInfo.myColor = _Color;
        }
    }

    private bool ClearCheck()
    {
        return maxPoint == point;
    }

    private void ClickBtn(int idx)
    {
        if (ClearCheck()) return;

        if (btn[idx].GetComponent<ButtonInfo>().myColor == Color.clear) return;

        if (index[0] == idx) return;

        if(index[0] != -1 && btn[index[0]].GetComponent<ButtonInfo>().myColor == Color.clear) return;

        index[pivot] = idx;

        if (pivot == 1)
        {
            pivot = 0;

            if (btn[index[0]].GetComponent<ButtonInfo>().myColor
                == btn[index[1]].GetComponent<ButtonInfo>().myColor)
            {
                btn[index[0]].GetComponent<ButtonInfo>().myColor = Color.clear;
                btn[index[1]].GetComponent<ButtonInfo>().myColor = Color.clear;

                point++;

                if (ClearCheck())
                {
                    endPuzzle.SetActive(true);
                    StartCoroutine(EndGame());
                }
            }

            index[0] = index[1] = -1;
        }
        else pivot++;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetString("ButtonPuzzle2", "clear");
        SceneManager.LoadScene("StartScene");
    }
}