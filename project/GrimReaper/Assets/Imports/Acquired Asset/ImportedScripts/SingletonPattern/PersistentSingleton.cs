using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    public bool AutoUnparentOnAwake = true;
    protected static T instance;
    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var go = new GameObject(typeof(T).Name + " Generated");
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        InitializeSingleton();
    }
    protected virtual void InitializeSingleton()
    {
        if (!Application.isPlaying) { return; }
        if (AutoUnparentOnAwake) { transform.SetParent(null); }
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}