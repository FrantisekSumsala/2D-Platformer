using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private EntityHealth playerHealth;

    [SerializeField]
    private LevelFinish levelFinish;

    [SerializeField]
    private float resetWaitTime = 1f;

    [SerializeField]
    private float blackScreenTransitionTime = 1f;

    [SerializeField]
    private UnityEngine.UI.Image blackScreen;

    private void OnEnable()
    {
        levelFinish.OnPlayerFinish += FinishLevel;
        playerHealth.EntityDied += ResetLevel;
    }

    private void OnDisable()
    {
        levelFinish.OnPlayerFinish -= FinishLevel;
        playerHealth.EntityDied -= ResetLevel;
    }

    private void ResetLevel()
    {
        StartCoroutine(ReloadLevel());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void FinishLevel()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator ReloadLevel()
    {
        float timer = 0f;
        while (timer < blackScreenTransitionTime)
        {
            timer += Time.deltaTime;
            Color c = blackScreen.color;
            c.a = Mathf.Lerp(0, 1, timer / blackScreenTransitionTime);
            blackScreen.color = c;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(resetWaitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        yield return null;
    }
}
