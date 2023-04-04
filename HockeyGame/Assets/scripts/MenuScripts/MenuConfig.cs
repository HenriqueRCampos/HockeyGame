using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuConfig : MonoBehaviour
{
    private static MenuConfig instance;
    public static float botVelocity;
    public static float botForce;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
