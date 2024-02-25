using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotMaker : MonoBehaviour
{
    public static ScreenShotMaker Inctance;
    private int  _screenNumber=0;
    private void Awake()
    {
        if (Inctance == null)
        {
            Inctance = this;
            transform.parent = null;
            Initialize();
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MakeScreen();
    }
    public void MakeScreen()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            ScreenCapture.CaptureScreenshot("Screen"+_screenNumber.ToString()+".png");
            _screenNumber++;
            SaveScreenNumber();
        }
    }
    private void Initialize()
    {
        if(PlayerPrefs.HasKey("PPScreenNumber"))
        {
            _screenNumber = PlayerPrefs.GetInt("PPScreenNumber");
        }
        else
        {
            _screenNumber = 0;
            PlayerPrefs.SetInt("PPScreenNumber", _screenNumber);
        }
    }

    private void SaveScreenNumber()
    {
        PlayerPrefs.SetInt("PPScreenNumber", _screenNumber);
    }
}
