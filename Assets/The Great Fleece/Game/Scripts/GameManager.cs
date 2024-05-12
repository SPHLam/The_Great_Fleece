using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
    public PlayableDirector introCutscene;
    private void Awake()
    {
        _gameManagerInstance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 60f;
        }
    }
}
