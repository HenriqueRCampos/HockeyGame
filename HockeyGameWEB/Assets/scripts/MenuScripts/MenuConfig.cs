using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MenuConfig : MonoBehaviour
{
    private static MenuConfig instance;
    public static int totalPlayers;
    public static float botVelocity;
    public static float botForce;
    public static float playeRange;
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
