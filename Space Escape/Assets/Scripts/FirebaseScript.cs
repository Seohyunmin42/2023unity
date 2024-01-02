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
    private FirebaseAuth auth;  // �α��� / ȸ������ �� ���
    private FirebaseUser user;  // ������ �Ϸ�� ���� ����

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
                Debug.Log("�α׾ƿ�");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(signed)
            {
                Debug.Log("�α���");
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
                Debug.LogError("ȸ������ ���");
                return;
            }
            if (task.IsFaulted)
            {
                //�̸��� ������ �� 
                Debug.LogError("ȸ������ ����");
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.LogError("ȸ������ ����");
        });
    }
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("�α��� ���");
                return;
            }
            if (task.IsFaulted)
            {
                //�̸��� ������ �� 
                Debug.LogError("�α��� ����");
                return;
            }
            AuthResult authResult = task.Result;
            FirebaseUser newUser = authResult.User;
            Debug.LogError("�α��� ����");
        });
    }
    public void Logout()
    {
        auth.SignOut();
        Debug.Log("�α׾ƿ� �Ϸ�");
    }
}
