using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenuWindow : ViewMethods
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Toggle _musicEffects;
    [SerializeField] private Toggle _gameSound;

    private void Start()
    {
        SetButtonsListener();
        SetTogglesAction();
        SetParams();
        MusicManager.Music.ActivateGameMusic(true);
        MusicManager.Music.ActivateMusicEffects(true);
        AddOnPointerEnter(new[] { _backButton }, EventTriggerType.PointerEnter,
            (data) => MusicManager.Music.PlaySound("Buttons Music", true));
    }

    /// <summary>
    /// Установка значений параметров при открытии меню настройки
    /// </summary>
    public override void SetParams()
    {
        _musicEffects.isOn = ApplicationData.AppData.IsOnMusicEffects;
        _gameSound.isOn = ApplicationData.AppData.IsOnGameSound;
    }

    /// <summary>
    /// Метод меняющий состояние активности музыкальных эффектов в игре
    /// </summary>
    private void ChangeActiveMusicEffect()
    {
        var appData = ApplicationData.AppData;
        appData.IsOnMusicEffects = !appData.IsOnMusicEffects;
        MusicManager.Music.ActivateMusicEffects(appData.IsOnMusicEffects);
    }

    /// <summary>
    /// Метод меняющий состояние активности фоновой музыки в игре
    /// </summary>
    private void ChangeActiveGameSound()
    {
        var appData = ApplicationData.AppData;
        appData.IsOnGameSound = !appData.IsOnGameSound;
        MusicManager.Music.ActivateGameMusic(appData.IsOnGameSound);
    }

    /// <summary>
    /// Метод задающий выполняеемый мотод кнопок в окне насатройки
    /// </summary>
    private void SetButtonsListener()
    {
        _backButton.onClick.AddListener(() => ViewManager.Instance.Show<MainMenu>());
    }

    /// <summary>
    /// Метод задающий выполняеемый мотод тогглов  в окне насатройки
    /// </summary>
    private void SetTogglesAction()
    {
        AddOnPointerEnter(new Object[] { _musicEffects }, EventTriggerType.PointerDown,
            (data) => ChangeActiveMusicEffect());
        AddOnPointerEnter(new Object[] { _gameSound }, EventTriggerType.PointerDown, 
            (data) => ChangeActiveGameSound());
    }
}
