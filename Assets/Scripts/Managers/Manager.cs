using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A base class that all managers inherit. Has functions that check if a manager of the same type already exists within a scene,
//and attempts to load a prefab of one if absent in the scene.

public class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private bool isPersist;

    private static T _instance;

    public static T Instance
    {
        get
        {
            //If there is no instance yet
            if (!_instance)
            {
                //Finds an existing manager of the same type within the scene.
                _instance = (T)FindObjectOfType(typeof(T));
            }
            //If the scene doesn't have a manager of the same type
            if (!_instance)
            {
                //Finds a prefab of a manager of the same type within the game's resources and instantiates it.
                if (Resources.Load<T>("System/" + typeof(T).Name) != null)
                {
                    T instance = Resources.Load<T>("System/" + typeof(T).Name);
                    T go = (T)Instantiate(instance);
                    _instance = go;
                }
                //If there is no prefab, sets our instance to null
                else
                {
                    _instance = null;
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        //If there is no instance, sets self as the instance
        if (_instance == null)
            _instance = this as T;

        //Checks if there is already an instance
        if (_instance != null)
        {
            //Checks if the existing instance is not the self. If the existing instance is not the self, destroy self
            if (_instance != this as T)
            {
                Destroy(this.gameObject);
            }
        }

        if (isPersist)
            DontDestroyOnLoad(this.gameObject);
    }
}