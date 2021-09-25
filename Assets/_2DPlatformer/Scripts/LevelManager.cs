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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void FinishLevel()
    {
        throw new System.NotImplementedException();
    }
}
