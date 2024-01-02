using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject Login;
    public GameObject register;
    public GameObject options;
    public GameObject menu;
    public GameObject rank;
    public GameObject about;
    public GameObject modify;
    public GameObject list;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button loginButton;
    public Button registerButton;
    public Button adminButton;
    public Button optionButton;
    public Button rankButton;
    public Button aboutButton;
    public Button quitButton;
    public Button modifyButton;

    public List<Button> returnButtonMenu;
    public List<Button> returnButtonLogin;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);
        registerButton.onClick.AddListener(Register);
        rankButton.onClick.AddListener(EnableRank);
        modifyButton.onClick.AddListener(EnableModify);
        adminButton.onClick.AddListener(EnableList);

        foreach (var item in returnButtonMenu)
        {
            item.onClick.AddListener(EnableMenu);
        }

        foreach (var item in returnButtonLogin)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }

    public void Register()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(true);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }
    public void Enablerank()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(true);
        list.SetActive(false);
    }

    public void EnableMenu()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(true);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }
    public void EnableMainMenu()
    {
        Login.SetActive(true);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }
    public void EnableOption()
    {
        Login.SetActive(false);
        options.SetActive(true);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }
    public void EnableAbout()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(true);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(false);
    }
    public void EnableRank()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(true);
        list.SetActive(false);
    }

    public void EnableModify()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(true);
        rank.SetActive(false);
        list.SetActive(false);
    }

    public void EnableList()
    {
        Login.SetActive(false);
        options.SetActive(false);
        register.SetActive(false);
        menu.SetActive(false);
        about.SetActive(false);
        modify.SetActive(false);
        rank.SetActive(false);
        list.SetActive(true);
    }
}
