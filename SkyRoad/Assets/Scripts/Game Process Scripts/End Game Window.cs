using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private Button _toMainMenuButton;
    [SerializeField] private Button _restartGameButton;
    
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private MainMenu _mainMenu;

    private void Start()
    {
        _toMainMenuButton.onClick.AddListener(ToMainMenuButtonActivity);
        _restartGameButton.onClick.AddListener(RestartGameButton);
        OnPointerEnterButtons(new []{_toMainMenuButton,_restartGameButton});
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
        for (var i = 10; i > 0; i--)
        {
            if (ApplicationData.AppData.GameRes[i].ScoreValue > ApplicationData.AppData.GameRes[i - 1].ScoreValue)
            {
                var res = ApplicationData.AppData.GameRes[i - 1];
                ApplicationData.AppData.GameRes[i - 1] = ApplicationData.AppData.GameRes[i];
                ApplicationData.AppData.GameRes[i] = res;
            }
        }
    }
    private void SetTextParams()
    {
        if (ApplicationData.AppData.GameRes[10].ScoreValue > ApplicationData.AppData.GameRes[0].ScoreValue)
        {
            _resultText.text = "Новый Рекорд!";
            GameMusic.Music.PlayWinMusic();
        }
        else
        {
            _resultText.text = "Результаты:";
        }
        
        _scoreText.text = Mathf.Round(ApplicationData.AppData.GameScore).ToString();
        _timeText.text = Mathf.Round(ApplicationData.AppData.GameTime).ToString();
    }

    private void SaveGameResult()
    {
        ApplicationData.AppData.GameRes[10].Date = DateTime.Today;
        ApplicationData.AppData.GameRes[10].Time = Mathf.Round(ApplicationData.AppData.GameTime);
        ApplicationData.AppData.GameRes[10].ScoreValue = Mathf.Round(ApplicationData.AppData.GameScore);
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
        GameMusic.Music.PlayMenuMusic(false);
        ViewManager.Instance.ActivateMenuCamera(false);
        ViewManager.Instance.Show<GameProccesWindow>();
        GameMusic.Music.PlayGameMusic(true);
    }
}