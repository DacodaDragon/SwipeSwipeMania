using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Same as the Singleton but with DontDestroyOnLoad functionality.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DDOLSingleton<T> : MonoBehaviour where T : Component
{
    private static T m_Instance;
    /// <summary>
    /// Referencing this field creates an instance if it doesn't already exist.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<T>();
                if (m_Instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    m_Instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return m_Instance;
        }
    }

    public virtual void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
