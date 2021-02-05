using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class ColorPuzzle : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] [Range(0f, 1f)] float endTime;
    [SerializeField] Color myColor;

    public List<Color> colors;
    [Space]

    Image img;

    public bool isActive = false;

    int idx;

    float t = 0f;

    int len;
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            img.color = Color.Lerp(img.color, colors[idx], lerpTime*Time.deltaTime);

            t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
            if(t> endTime)
            {
                t = 0f;
                idx++;
                if (idx == colors.Count) idx = 0;
            }
        }
    }
}
