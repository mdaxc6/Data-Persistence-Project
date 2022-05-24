using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class UIManager : MonoBehaviour
{

    public void StartGame()
    {
        GetPlayerName();
        DataManager.instance.LoadScore();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReturnToMenu()
    {
        DataManager.instance.SaveHighScore();
        SceneManager.LoadScene(0);
    }

    public void GetPlayerName()
    {
        var input = gameObject.transform.Find("TextInput").GetComponent<InputField>();
        if (input.text != null && input.text != "")
        {
            DataManager.instance.PlayerName = input.text;
        }
    }

}
