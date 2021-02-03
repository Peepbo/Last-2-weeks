using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ButtonPuzzle2 : MonoBehaviour
{
    public List<GameObject> btn;

    private void Awake()
    {
        GameObject[] obj = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++) 
            obj[i] = transform.GetChild(i).gameObject;

        for (int i = 0; i < obj.Length; i++)
        {
            for (int j = 0; j < obj[i].transform.childCount; j++)
            {
                obj[i].transform.GetChild(j).gameObject.AddComponent<ButtonInfo>();
                btn.Add(obj[i].transform.GetChild(j).gameObject);
            }
        }

        //빨간색 2의 배수 개
        //파란색 2의 배수 개
        //노란색 2의 배수 개
        //초록색 2의 배수 개

        //2a + 2b + 2c + 2d + 2e = btn.count;
        int a, b, c, d;
        //0~29 .. 14
        //29-14 = 30

        //48
        //16,14,12,12

        a = 2 * Random.Range(5, 9);
        Debug.Log("a : " + a);
        b = 2 * Random.Range(5, 8);
        Debug.Log("b : " + b);
        c = 2 * Random.Range(5, 7);
        Debug.Log("c : " + c);
        d = btn.Count - a - b - c;
        Debug.Log("d : " + d);

        int[] _counts = { a, b, c, d };
        Color[] _colors = { Color.red, Color.blue, Color.yellow, Color.green };

        //레드가 a개
        //블루가 b개
        //옐로가 c개
        //그린이 d개
        int _order = 0;
        int _colorOrder = 0;
        for(int i = 0; i < btn.Count; i++)
        {
            if (_order == _counts[_colorOrder])
            {
                _order = 0;
                _colorOrder++;
                if (_order == _counts[_colorOrder]) _colorOrder++;
            }
            else _order++;

            btn[i].GetComponent<ButtonInfo>().myColor = _colors[_colorOrder];
        }

        Suffle();
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
}
