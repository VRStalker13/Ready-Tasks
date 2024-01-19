using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameProccesWindow : ViewMethods
{
    [SerializeField] private Button _buttonPause;
    [SerializeField] private GameObject _gameEnvironmentPrefab;
    [SerializeField] private GameObject _gameEnvironmentParent;
    [SerializeField] private GameObject _gameUI;

    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _time;

    private ViewMethods _menu;
    private GameObject _game;
    private bool _isVisible;

    private void Start()
    {
        _isVisible = false;
        _menu = ViewManager.Instance.GetView<PauseMenuWindow>();
        _menu.gameObject.SetActive(_isVisible);
        _buttonPause.onClick.AddListener(PauseButtonActivity);
        AddOnPointerEnter(new []{_buttonPause},EventTriggerType.PointerEnter,(data) => MusicManager.Music.PlaySound("Buttons Music",true));
    }

    private void Update()
    {
        GameResultCounter();
    }
    
    private void GameResultCounter()
    {
        var appData = ApplicationData.AppData;
        
        if (appData.GameProcessIsOn)
        {
            if(Input.GetKey(KeyCode.Space))
                appData.GameScore += 2f * Time.deltaTime;
            else
                appData.GameScore += Time.deltaTime;

            _score.text = Mathf.Round(appData.GameScore).ToString();
            appData.GameTime += Time.deltaTime;
            _time.text = Mathf.Round(appData.GameTime).ToString();
        }
    }

    private void PauseButtonActivity()
    {
        _isVisible = !_isVisible;
        _menu.gameObject.SetActive(_isVisible);
        _menu.SetParams();
        Time.timeScale = _isVisible ? 0f : 1f;
    }
    
    public override void SetParams()
    {
        MusicManager.Music.PlaySound("Game Music",true);
        Time.timeScale = 1;
        _gameUI.SetActive(true);
        CameraMethods.CamMethods.OpenCamera("Game Camera");
        _game = Instantiate(_gameEnvironmentPrefab, _gameEnvironmentParent.transform, true);
        _game.SetActive(true);
        ApplicationData.AppData.GameScore = 0f;
        ApplicationData.AppData.GameTime = 0f;
        ApplicationData.AppData.GameProcessIsOn = true;
    }

    public override void Hide()
    {
        ApplicationData.AppData.GameProcessIsOn = false;
        CameraMethods.CamMethods.OpenCamera("Menu Camera");
        _gameUI.SetActive(false);
        MusicManager.Music.PlaySound("Game Music",false);
        Destroy(_game);
    }
}
