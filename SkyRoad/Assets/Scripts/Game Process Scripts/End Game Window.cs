using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndGameWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Button _toMainMenuButton;
    [SerializeField] private Button _restartGameButton;
    
    [SerializeField] private GameObject _gameUI;

    private void Start()
    {   if(ApplicationData.AppData.GameRes.Length==0) 
            CreateStartRecordsList();
        
        _toMainMenuButton.onClick.AddListener(ToMainMenuButtonActivity);
        _restartGameButton.onClick.AddListener(RestartGameButton);
        AddOnPointerEnter(new []{_toMainMenuButton,_restartGameButton},EventTriggerType.PointerEnter,
            (data) => MusicManager.Music.PlaySound("Buttons Music",true));
    }

    public override void SetParams()
    {
        _gameUI.SetActive(false);
        SaveGameResult();
        SetTextParams();
        SortGameResults(); 
    }

    private void SortGameResults()
    {
        var appData = ApplicationData.AppData;
        
        for (var i = 10; i > 0; i--)
        {
            if (appData.GameRes[i].ScoreValue > appData.GameRes[i - 1].ScoreValue)
            {
                var res = appData.GameRes[i - 1];
                appData.GameRes[i - 1] = appData.GameRes[i];
                appData.GameRes[i] = res;
            }
        }
    }
    private void SetTextParams()
    {
        var appData = ApplicationData.AppData;
        
        if (appData.GameRes[10].ScoreValue > appData.GameRes[0].ScoreValue)
        {
            _resultText.text = "Новый Рекорд!";
            MusicManager.Music.PlaySound("Win Music",true);
        }
        else
        {
            _resultText.text = "Результаты:";
        }
        
        _scoreText.text = Mathf.Round(appData.GameScore).ToString();
        _timeText.text = Mathf.Round(appData.GameTime).ToString();
    }
    
    private void CreateStartRecordsList()
    {
        for (var i = 0; i < ApplicationData.AppData.GameRes.Length; i++)
            ApplicationData.AppData.GameRes[i] = new GameResultData();
    }

    private void SaveGameResult()
    {
        var appData = ApplicationData.AppData;
        appData.GameRes[10].Date = DateTime.Today;
        appData.GameRes[10].Time = Mathf.Round(appData.GameTime);
        appData.GameRes[10].ScoreValue = Mathf.Round(appData.GameScore);
    }

    private void ToMainMenuButtonActivity()
    {
        gameObject.SetActive(false);
        ViewManager.Instance.Show<MainMenu>();
    }

    private void RestartGameButton()
    {
        gameObject.SetActive(false);
        ViewManager.Instance.GetView<MainMenuBackgroundWindow>().Hide();
        MusicManager.Music.PlaySound("Menu Music",false);
        CameraMethods.CamMethods.OpenCamera("Game Camera");
        ViewManager.Instance.Show<GameProccesWindow>();
        MusicManager.Music.PlaySound("Game Music",true);
    }
}
