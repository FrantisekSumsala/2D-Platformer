using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        Debug.Log("QUIT GAME!");
#endif

        Application.Quit();
    }

}
