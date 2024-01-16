using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : ViewMethods
{
    [SerializeField]private Button _startGameButton;
    [SerializeField]private Button _recordsWindowButton;
    [SerializeField]private Button _settingsWindowButton;
    [SerializeField]private Button _exitProgramButton;
    
    [SerializeField]private GameObject _mainMenuBackground;

    private void Awake()
    {
        ApplicationData.AppData.CreateStartRecordsList();
    }

    private void Start()
    {
        SetButtons();
    }

    private void SetButtons()
    {
        _startGameButton.onClick.AddListener(StartNewGame);
        _recordsWindowButton.onClick.AddListener(ShowRecordsWindow);
        _settingsWindowButton.onClick.AddListener(ShowSettingsWindow);
        _exitProgramButton.onClick.AddListener(ExitGame);
        AddOnPointerEnter(new []{_startGameButton,_recordsWindowButton,_settingsWindowButton,_exitProgramButton},
            EventTriggerType.PointerEnter,(data) => GameMusic.Music.PlayButtonsMusic(true));
    }
    
    public override void SetParams()
    {
        ActivateMenuBackgroundEffects(true);
    }

    private void ActivateMenuBackgroundEffects(bool isActive)
    {
        _mainMenuBackground.SetActive(isActive);
        GameMusic.Music.PlayMenuMusic(isActive);
        CameraMethods.CamMethods.OpenCamera(isActive? "Menu Camera":"Game Camera");
    }

    private void StartNewGame()
    {
        ActivateMenuBackgroundEffects(false);
        GameMusic.Music.PlayGameMusic(true);
        ViewManager.Instance.Show<GameProccesWindow>();
    }
    
    private void ShowRecordsWindow()
    {
        ViewManager.Instance.Show<RecordsMenuWindow>();
    }
    
    private void ShowSettingsWindow()
    {
        ViewManager.Instance.Show<SettingsMenuWindow>();
    }
    
    private void ExitGame()
    {
        ViewManager.Instance.Show<ExitСonfirmationWindow>(false);
    }
}
