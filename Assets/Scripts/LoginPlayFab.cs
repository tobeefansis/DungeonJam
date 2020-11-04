using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class LoginPlayFab : Singleton<LoginPlayFab>
{
    public string TitleId = "FB293";
    public string PlayFabId;
    public bool IsLogin;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = TitleId;
        }
        var request = new LoginWithAndroidDeviceIDRequest() { AndroidDeviceId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(request, Accept, OnError);
    }

    public static void OnError(PlayFabError obj)
    {
        Debug.Log(obj.GenerateErrorReport());
    }

    private void Accept(LoginResult obj)
    {
        PlayFabId = obj.PlayFabId;
        IsLogin = true;
        SceneManager.LoadScene("Game");
    }
}