using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShortcutClick : MonoBehaviour
{
    [SerializeField]
    private KeyCode buttonShortcut;

    [SerializeField]
    private UnityEngine.UI.Button button;

    private void Update()
    {
        if (Input.GetKeyUp(buttonShortcut))
        {
            button.onClick.Invoke();
        }
    }


}
