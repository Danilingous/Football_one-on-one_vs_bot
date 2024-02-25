using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSound : MonoBehaviour
{
    public static BackSound Inctance;

    private void Awake()
    {
        if (Inctance == null)
        {
            Inctance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
