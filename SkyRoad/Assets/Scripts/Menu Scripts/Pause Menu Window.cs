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
        AddOnPointerEnter(new[] { _toMainMenuButton, _changeActivMusicEffectsButton, _changeActivGameMusicButton },
            EventTriggerType.PointerEnter, (data) => MusicManager.Music.PlaySound("Buttons Music", true));
    }

    public override void SetParams()
    {
        _changeActivMusicEffectsButton.image.color = ApplicationData.AppData.IsOnMusicEffects ? Color.green : Color.red;
        _changeActivGameMusicButton.image.color = ApplicationData.AppData.IsOnGameSound ? Color.green : Color.red;
    }

    private void ChangeMusicEffects()
    {
        var appData = ApplicationData.AppData;
        appData.IsOnMusicEffects = !appData.IsOnMusicEffects;
        MusicManager.Music.ActivateMusicEffects(appData.IsOnMusicEffects);
        _changeActivMusicEffectsButton.image.color = appData.IsOnMusicEffects ? Color.green : Color.red;
    }

    private void ChangeGameMusic()
    {
        var appData = ApplicationData.AppData;
        appData.IsOnGameSound = !appData.IsOnGameSound;
        MusicManager.Music.ActivateGameMusic(appData.IsOnGameSound);
        _changeActivGameMusicButton.image.color = appData.IsOnGameSound ? Color.green : Color.red;
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