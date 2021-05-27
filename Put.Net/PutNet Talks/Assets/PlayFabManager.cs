using System;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public InputField EmailInput;
    public InputField PasswordInput;

    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = EmailInput.text,
            Password = PasswordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailInput.text,
            Password = PasswordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    }

    public void ResetPassword()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailInput.text,
            TitleId = "31DD9"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnResetSuccess, OnResetError);
    }


    //Events
    private void OnRegisterError(PlayFabError obj)
    {
        Debug.Log(obj);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult obj)
    {
        Debug.Log("Registered and logged in!");
    }

    private void OnLoginError(PlayFabError obj)
    {
        Debug.Log(obj);
    }

    private void OnLoginSuccess(LoginResult obj)
    {
        Debug.Log("Logged in!");
    }

    private void OnResetError(PlayFabError obj)
    {
        Debug.Log(obj);
    }

    private void OnResetSuccess(SendAccountRecoveryEmailResult obj)
    {
        Debug.Log("Email sent!");
    }
}