using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    [SerializeField]
    private bool destroyDuplicateGameObjects = false;

    public static T Instance { get { return _instance; }}

    private static T _instance = null;

    protected virtual void Start()
    {
        if (_instance != null)
            DestroyDuplicateSelf();
        else
        {
            var other = FindObjectOfType<T>();
            if (other != null && other != this)
                DestroyDuplicateSelf();
            else
                _instance = (T)this;
        }

    }

    private void DestroyDuplicateSelf()
    {
        if (destroyDuplicateGameObjects)
            Destroy(this.gameObject);
        else
            Destroy(this);

    }
}
