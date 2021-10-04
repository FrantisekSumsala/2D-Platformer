using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadSceneDelayed()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    private IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForEndOfFrame();
        LoadScene();
        yield return null;
    }
}
