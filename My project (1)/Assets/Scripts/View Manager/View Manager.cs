using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    public List<Human> ListHum = new List<Human>();
    public string ShowHumanNumber = new string("");
    public string ChangeParamNumber = new string("");
    
    public static ViewManager s_instance;
    [SerializeField] private View _startingView;
    [SerializeField] private View[] _views;
    [SerializeField] private Button _closeProgramButton;
    [SerializeField] private Button _toMainMenuButton;
    [SerializeField] public Button _toNextWindowButton;
    public View _currentView;
    public Button[] _addMenuButtons;
    public int _choosenNumberOfHuman;
    public int _choosenNumberOfParam;
    
    public void Show<T>(bool hide = true) where T : View
    {
        for (var i = 0; i < s_instance._views.Length; i++)
        {
            if (s_instance._views[i] is T)
            {
                if (s_instance._currentView != null && hide == true)
                    s_instance._currentView.Hide();

                s_instance._views[i].Show();
                
                if(hide)
                    s_instance._currentView = s_instance._views[i];
            }
        }
    }

    private void Awake() => s_instance = this;
    
    private void Start()
    {
        Initialize();
        
        if (s_instance._startingView != null)
            Show<MainMenuWindow>();
    }

    private void Update()
    {
        s_instance._toMainMenuButton.gameObject.SetActive(s_instance._currentView is not MainMenuWindow);
    }

    private void Initialize()
    {
        foreach (var view in s_instance._views)
        {
            view.Initialize();
            view.Hide();
        }

        s_instance._toNextWindowButton.interactable = true;
        s_instance._toMainMenuButton.onClick.AddListener(ToMainMenu);
        s_instance._closeProgramButton.onClick.AddListener(CloseProgram);
    }

    public void ToNextWindow()
    {
        s_instance._toNextWindowButton.onClick.RemoveAllListeners();

        if (s_instance._currentView is HumansListToChangeWindow)
            s_instance._toNextWindowButton.onClick.AddListener(() => ViewManager.s_instance.Show<ParamsListWindow>());

        if (s_instance._currentView is HumansListToShowWindow)
            s_instance._toNextWindowButton.onClick.AddListener(() => ViewManager.s_instance.Show<HumanInformationWindow>());

        if (s_instance._currentView is ParamsListWindow)
            s_instance._toNextWindowButton.onClick.AddListener(() => ViewManager.s_instance.Show<ChangeProccesWindow>());

        if (s_instance._currentView is ParamsListWindow or HumansListToShowWindow or HumansListToChangeWindow)
        {
            s_instance._toNextWindowButton.onClick.AddListener(() =>
                ViewManager.s_instance._toNextWindowButton.gameObject.SetActive(false));
        }
            
    }

    public void ToMainMenu()
    {
        s_instance._toMainMenuButton.gameObject.SetActive(false);
        
        if(s_instance._currentView is AddMenuWindow)
             AddMenuWindow.SetVisible(true);
        
        Show<MainMenuWindow>();
        HideAllViews();
    }

    private void HideAllViews()
    {
        foreach (var view in s_instance._views)
            if(view is not MainMenuWindow)
                view.Hide();
    }
    
    public string ShowListHumans()
    {
        var count = s_instance.ListHum.Count;
        var text = "Human List:\n";
            
        for (var i = 0; i < count; i++)            
            text = $"{text}\n{i + 1}. {s_instance.ListHum[i].FirstName} " +
                   $"{s_instance.ListHum[i].LastName} " +
                   $"{s_instance.ListHum[i].Patronymic}"; 
            
        return text;
    }
    
    public void CloseProgram() => Application.Quit();
}
