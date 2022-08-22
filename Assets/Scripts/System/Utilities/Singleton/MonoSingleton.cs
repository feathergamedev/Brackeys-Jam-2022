using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject($"SINGLETON_{typeof(T)}", typeof(T)).GetComponent<T>();
            }

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = gameObject.GetComponent<T>();
            _instance.Init();
        }
    }

    public virtual void Init()
    {
        gameObject.name = $"{typeof(T)}_Singleton";
        Debug.Log($"{typeof(T)} initialized.");
        DontDestroyOnLoad(gameObject);
    }
}