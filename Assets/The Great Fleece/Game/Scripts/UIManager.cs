using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _uiManager;
    public static UIManager UIManagerInstance
    {
        get
        {
            if (_uiManager == null)
            {
                Debug.LogError("UI Manager is null!");
            }
            return _uiManager;
        }
    }
    private void Awake()
    {
        _uiManager = this;
    }
    // Restart function
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    // Quit function
    public void Quit()
    {
        Application.Quit();
    }
}
