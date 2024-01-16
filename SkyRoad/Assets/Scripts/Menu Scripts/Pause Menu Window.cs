using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuWindow : ViewMethods
{
    [SerializeField] private Button _changeActivMusicEffectsButton;
    [SerializeField] private Button _changeActivGameMusicButton;
    [SerializeField] private Button _toMainMenuButton;

    [SerializeField] private GameObject _gameProcessWindow;

    private void Start()
    {
        _changeActivMusicEffectsButton.onClick.AddListener(() => ChangeMusicEffects());
        _changeActivGameMusicButton.onClick.AddListener(() => ChangeGameMusic());
        _toMainMenuButton.onClick.AddListener(() => ToMainMenuButton());
        AddOnPointerEnter(new []{_toMainMenuButton,_changeActivMusicEffectsButton,_changeActivGameMusicButton},
            EventTriggerType.PointerEnter,(data) => GameMusic.Music.PlayButtonsMusic(true));
    }

    public override void SetParams()
    {
        _changeActivMusicEffectsButton.image.color = ApplicationData.AppData._isOnMusicEffects ? Color.green : Color.red;
        _changeActivGameMusicButton.image.color = ApplicationData.AppData._isOnGameSound ? Color.green : Color.red;
    }

    private void ChangeMusicEffects()
    {
        ApplicationData.AppData._isOnMusicEffects = !ApplicationData.AppData._isOnMusicEffects;
        GameMusic.Music.ActivateMusicEffects(ApplicationData.AppData._isOnMusicEffects);
        _changeActivMusicEffectsButton.image.color = ApplicationData.AppData._isOnMusicEffects ? Color.green : Color.red;
    }
    
    private void ChangeGameMusic()
    {
        ApplicationData.AppData._isOnGameSound = !ApplicationData.AppData._isOnGameSound;
        GameMusic.Music.ActivateGameMusic(ApplicationData.AppData._isOnGameSound);
        _changeActivGameMusicButton.image.color = ApplicationData.AppData._isOnGameSound ? Color.green : Color.red;
    }

    private void ToMainMenuButton()
    {
        ViewManager.Instance.Show<MainMenu>();
        gameObject.SetActive(false);
        _gameProcessWindow.SetActive(false);
        Time.timeScale = 1;
        ViewManager.Instance.GetView<GameProccesWindow>().Hide();
    }
}
