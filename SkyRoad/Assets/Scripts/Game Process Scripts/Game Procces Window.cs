using TMPro;
using UnityEngine;
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
        OnPointerEnterButtons(new Button[]{_buttonPause});
    }

    private void Update()
    {
        GameResultCounter();
    }

    private void GameResultCounter()
    {
        if (ApplicationData.AppData.GameProcessIsOn)
        {
            if(Input.GetKey(KeyCode.Space))
                ApplicationData.AppData.GameScore += 2f * Time.deltaTime;
            else
                ApplicationData.AppData.GameScore += Time.deltaTime;

            _score.text = Mathf.Round(ApplicationData.AppData.GameScore).ToString();
            
            ApplicationData.AppData.GameTime += Time.deltaTime;
            _time.text = Mathf.Round(ApplicationData.AppData.GameTime).ToString();
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
        GameMusic.Music.PlayGameMusic(true);
        Time.timeScale = 1;
        _gameUI.SetActive(true);
        ViewManager.Instance.ActivateMenuCamera(false);
        _game = Instantiate(_gameEnvironmentPrefab, _gameEnvironmentParent.transform, true);
        _game.SetActive(true);
        
        ApplicationData.AppData.GameScore = 0f;
        ApplicationData.AppData.GameTime = 0f;
        ApplicationData.AppData.GameProcessIsOn = true;
    }

    public override void Hide()
    {
        ApplicationData.AppData.GameProcessIsOn = false;
        ViewManager.Instance.ActivateMenuCamera(true);
        _gameUI.SetActive(false);
        GameMusic.Music.PlayGameMusic(false);
        Destroy(_game);
    }
}
