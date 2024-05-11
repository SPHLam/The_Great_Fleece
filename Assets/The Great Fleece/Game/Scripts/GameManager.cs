using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManagerInstance;
    public static GameManager GameManagerInstance
    {
        get
        {
            if (_gameManagerInstance == null)
            {
                Debug.LogError("GameManager is null!");
            }
            return _gameManagerInstance;
        }
    }
    public bool haveCard { get; set; }
    private void Awake()
    {
        _gameManagerInstance = this;
    }
}
