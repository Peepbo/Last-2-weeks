using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoveScene : MonoBehaviour
{
    public Image[] img;
    private void Start()
    {
        if(PlayerPrefs.HasKey("ButtonPuzzle")) img[0].color = Color.green;

        if (PlayerPrefs.HasKey("ButtonPuzzle2")) img[1].color = Color.green;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
