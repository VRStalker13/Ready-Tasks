using UnityEngine;
using UnityEngine.UI;

public class MainMenu : ViewMethods
{
    [SerializeField]private Button _startGameButton;
    [SerializeField]private Button _recordsWindowButton;
    [SerializeField]private Button _settingsWindowButton;
    [SerializeField]private Button _exitProgramButton;
    
    [SerializeField]private GameObject _mainMenuBackground;

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
        
        OnPointerEnterButtons(new Button[]{_startGameButton,_recordsWindowButton,_settingsWindowButton,_exitProgramButton});
    }
    
    public override void SetParams()
    {
        ActivateMenuBackgroundEffects(true);
    }

    private void ActivateMenuBackgroundEffects(bool isActive)
    {
        _mainMenuBackground.SetActive(isActive);
        GameMusic.Music.PlayMenuMusic(isActive);
        ViewManager.Instance.ActivateMenuCamera(isActive);
    }

    public void StartNewGame()
    {
        ActivateMenuBackgroundEffects(false);
        GameMusic.Music.PlayGameMusic(true);
        ViewManager.Instance.ActivateMenuCamera(false);
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
