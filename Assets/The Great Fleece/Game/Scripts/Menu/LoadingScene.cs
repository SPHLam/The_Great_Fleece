using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    private Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        _progressBar = transform.GetChild(1).gameObject.GetComponent<Image>();
        // Call coroutine to load the main scene
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        yield return null;

        // create an async operation = loadSceneAsync("Main")
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");

        // while operation isn't finished
        // progress bar fill amount = operation progress
        // yield waitforendofframe
        while(!asyncOperation.isDone)
        {
            _progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
