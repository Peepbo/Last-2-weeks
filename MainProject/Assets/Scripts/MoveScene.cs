using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoveScene : MonoBehaviour
{
    public Image img;
    private void Start()
    {
        if(PlayerPrefs.HasKey("ButtonPuzzle"))
        {
            img.color = Color.green;
        }
        
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
