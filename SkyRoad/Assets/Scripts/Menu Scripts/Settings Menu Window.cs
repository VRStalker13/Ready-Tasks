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
        GameMusic.Music.ActivateGameMusic(true);
        GameMusic.Music.ActivateMusicEffects(true);
    }

    /// <summary>
    /// Установка значений параметров при открытии меню настройки
    /// </summary>
    public override void SetParams()
    {
        _musicEffects.isOn = ApplicationData.AppData._isOnMusicEffects;
        _gameSound.isOn = ApplicationData.AppData._isOnGameSound;
    }

    /// <summary>
    /// Метод меняющий состояние активности музыкальных эффектов в игре
    /// </summary>
    private void ChangeActiveMusicEffect()
    {
        ApplicationData.AppData._isOnMusicEffects = !ApplicationData.AppData._isOnMusicEffects;
        GameMusic.Music.ActivateMusicEffects(ApplicationData.AppData._isOnMusicEffects);
        Debug.Log(ApplicationData.AppData._isOnMusicEffects.ToString());
    }
    
    /// <summary>
    /// Метод меняющий состояние активности фоновой музыки в игре
    /// </summary>
    private void ChangeActiveGameSound()
    {
        ApplicationData.AppData._isOnGameSound = !ApplicationData.AppData._isOnGameSound;
        GameMusic.Music.ActivateGameMusic(ApplicationData.AppData._isOnGameSound);
        Debug.Log(ApplicationData.AppData._isOnGameSound.ToString());
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
       EventTrigger.Entry entryForMusicEffects = new EventTrigger.Entry();
       entryForMusicEffects.eventID = EventTriggerType.PointerDown;
       entryForMusicEffects.callback.AddListener((data) => ChangeActiveMusicEffect());
       _musicEffects.gameObject.AddComponent<EventTrigger>().GetComponent<EventTrigger>().triggers.Add(entryForMusicEffects);
       
       EventTrigger.Entry entryForGameSound = new EventTrigger.Entry();
       entryForGameSound.eventID = EventTriggerType.PointerDown;
       entryForGameSound.callback.AddListener((data) => ChangeActiveGameSound());
       _gameSound.gameObject.AddComponent<EventTrigger>().GetComponent<EventTrigger>().triggers.Add(entryForGameSound);
    }
}
