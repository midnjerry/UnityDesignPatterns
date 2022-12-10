using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton<T>:MonoBehaviour where T : Component
{
    private static T s_instance; // s_instance will be some Component

    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<T>();
                //If null, GameObject with Component does not exist.
                if (s_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    s_instance = obj.AddComponent<T>();
                }
            }            
            return s_instance;
        }
    }
    public virtual void Awake()
    {
        if(s_instance == null)
        {
            s_instance = this as T;
            // Don't destroy on next Scene load.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   
}
