using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth; 
using UnityEngine.Rendering.Universal;
using System;
using Unity.VisualScripting;

public class FirebaseScript
{
    private static FirebaseScript instance = null;
    
    public static FirebaseScript Instance
    {
        get 
        {
            if(instance == null)
            {
                instance = new FirebaseScript();
            }
            return instance; 
        }
    }
    private FirebaseAuth auth;  // 로그인 / 회원가입 등 사용
    private FirebaseUser user;  // 인증이 완료된 유저 정보

    public string UserId => user.UserId;

    public Action<bool> LoginState;
    public void init()
    {
        auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            Logout();
        }

        auth.StateChanged += OnChanged;
    }
    private void OnChanged(object sender, EventArgs e) {
        if (auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                Debug.Log("로그아웃");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(signed)
            {
                Debug.Log("로그인");
                LoginState?.Invoke(true);
            }
        }
    }

    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => 
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
                return;
            }
            if (task.IsFaulted)
            {
                //이메일 비정상 등 
                Debug.LogError("회원가입 실패");
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.LogError("회원가입 성공");
        });
    }
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
                return;
            }
            if (task.IsFaulted)
            {
                //이메일 비정상 등 
                Debug.LogError("로그인 실패");
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.LogError("로그인 성공");
        });
    }
    public void Logout()
    {
        auth.SignOut();
        Debug.Log("로그아웃 완료");
    }
}
