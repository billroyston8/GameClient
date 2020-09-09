using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public InputField ipField;

    private void Awake()
    {
        ipField.text = Environment.GetCommandLineArgs().GetValue(1).ToString();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
        //if (!Client.instance.ConnectToServer(ipField.text))
        //{
        //    startMenu.SetActive(true);
        //    usernameField.interactable = true;
        //}
    }
}
