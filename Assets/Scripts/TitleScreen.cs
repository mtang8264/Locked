using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadFirstSceneAsync());
        }
    }

    IEnumerator LoadFirstSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
