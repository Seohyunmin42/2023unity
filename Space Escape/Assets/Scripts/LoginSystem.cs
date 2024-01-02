using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginSystem : MonoBehaviour
{
    public InputField email;
    public InputField password;

    public Text outputText;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseScript.Instance.LoginState += OnChangedStated;
        FirebaseScript.Instance.init();
    }

    private void OnChangedStated(bool sign)
    {
        outputText.text = sign ? "로그인 : " : "로그아웃 : ";
        outputText.text += FirebaseScript.Instance.UserId;
    }

    public void Create()
    {
        string e = email.text;
        string p = password.text;

        FirebaseScript.Instance.Create(e, p);
    }
    public void Login()
    {
        FirebaseScript.Instance.Login(email.text, password.text);
    }
    public void Logout()
    {
        FirebaseScript.Instance.Logout();
    }
}
