using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewManager : MonoBehaviour
{
    public static ViewManager _instance;
    
    public List<Human> ListHum = new List<Human>();// Список Всех людей
    
    [SerializeField] public GameObject ErrorWindow;
    [SerializeField] public TextMeshProUGUI ListHumansForChanging; // Список людей у которых будем менять значения
    [SerializeField] public TextMeshProUGUI HumanInformation;
    [SerializeField] public TextMeshProUGUI ListHumansForDeleting;// Список людей для удаления
    [SerializeField] public TextMeshProUGUI ListHumans;// Список людей для вывода инфы об одном
    [SerializeField] public TextMeshProUGUI HumansInformation; //Информация обо всех людях
    [SerializeField] public TextMeshProUGUI ListParamsForChanging; // Список параметров для изменения
    [SerializeField] private TextMeshProUGUI _nameChangingParametr;// Название изменяемого параметра
    [SerializeField] public TMP_InputField NewParameterValue;// Новое значение параметра при изменении
    
    [SerializeField] private View _startingView;// Начальный экран
    [SerializeField] private View[] _views;// Массив всех экранов приложения
    [SerializeField] private Button _closeProgramButton;// Кнопка закрытия приложения
    [SerializeField] public Button ToMainMenuButton;// Кнопка переводящая на начальное меню
    [SerializeField] public Button ToNextWindowButton;// Кнопка переключения на следующее окно
    [SerializeField] public Button CloseErrorWindowButton;
    
    public View CurrentView;// Текущее окно
    public Button[] AddMenuButtons;// Массив кнопок из окна добавления человека
    public int ChoosenNumberOfHuman;// Номер выбранного человека
    public int ChoosenNumberOfParam;// Порядковый номер параметра для изменения
    
    public void Show<T>(bool hide = true) where T : View
    {
        for (var i = 0; i < _instance._views.Length; i++)
        {
            if (_instance._views[i] is T)
            {
                if (_instance.CurrentView != null && hide)
                    _instance.CurrentView.Hide();

                _instance._views[i].Show();
                
                if(hide)
                    _instance.CurrentView = _instance._views[i];
            }
        }
    }

    private void Awake() => _instance = this;
    
    private void Start()
    {
        Initialize();
        
        if (_instance._startingView != null)
            Show<MainMenuWindow>();
    }

    private void Initialize()
    {
        foreach (var view in _instance._views)
        {
            view.Initialize();
            view.Hide();
        }
        _instance.ToMainMenuButton.gameObject.SetActive(false);
        _instance.ToMainMenuButton.onClick.AddListener(ToMainMenu);
        _instance._closeProgramButton.onClick.AddListener(CloseProgram);
        _instance.CloseErrorWindowButton.onClick.AddListener(CloseErrorWindow);
    }

    public void ToNextWindow()
    {
        _instance.ToNextWindowButton.onClick.RemoveAllListeners();

        if (_instance.CurrentView is ListHumansForChangingWindow)
        {
            _instance.ToNextWindowButton.onClick.AddListener(() => _instance.Show<ListParamsForChangingWindow>());
            _instance.ToNextWindowButton.onClick.AddListener(() => _instance.ListParamsForChanging.text = 
                _instance.ListHum[_instance.ChoosenNumberOfHuman].ListChanges());
        }

        if (_instance.CurrentView is ListHumansForShowingWindow)
        {
            _instance.ToNextWindowButton.onClick.AddListener(() => _instance.Show<HumanInformationWindow>());
            _instance.ToNextWindowButton.onClick.AddListener(() => 
                _instance.HumanInformation.text = HumanInformationWindow.ShowHuman());
        }

        if (_instance.CurrentView is ListParamsForChangingWindow)
        {
            _instance.ToNextWindowButton.onClick.AddListener(() => _instance.Show<ProcessChangingHumanWindow>());
            _instance.ToNextWindowButton.onClick.AddListener(NewParameterFormat);
            _instance.ToNextWindowButton.onClick.AddListener(NewParameterName);
        }
        
        _instance.ToNextWindowButton.onClick.AddListener(() => 
            _instance.ToNextWindowButton.gameObject.SetActive(false));
    }

    public void ToMainMenu()
    {
        _instance.ToMainMenuButton.gameObject.SetActive(false);
        AddingMenuWindow.SetVisible(true);
        Show<MainMenuWindow>();
        HideAllViews();
    }

    private void HideAllViews()
    {
        foreach (var view in _instance._views)
            if(view is not MainMenuWindow)
                view.Hide();
    }
    
    public string ShowListHumans()
    {
        var count = _instance.ListHum.Count;
        var text = "Human List:\n";
            
        for (var i = 0; i < count; i++)            
            text = $"{text}\n{i + 1}. {_instance.ListHum[i].FirstName} " +
                   $"{_instance.ListHum[i].LastName} " +
                   $"{_instance.ListHum[i].Patronymic}"; 
            
        return text;
    }
    
    private void NewParameterName()
    {
        switch (_instance.ChoosenNumberOfParam)
        {
            case 1:
                _instance._nameChangingParametr.text = "New name is: ";
                return;
            case 2:
                _instance._nameChangingParametr.text = "New Lastname is: ";
                return;
            case 3:
                _instance._nameChangingParametr.text = "New Patronymic is: ";
                return;
            case 4:
                _instance._nameChangingParametr.text = "New Birthday is: ";
                return;
        }

        if (_instance.ListHum[_instance.ChoosenNumberOfHuman] is Student)
        {
            switch (_instance.ChoosenNumberOfParam)
            {
                case 5:
                    _instance._nameChangingParametr.text = "New Faculty is: ";;
                    return;
                case 6:
                    _instance._nameChangingParametr.text = "New Course is: ";
                    return;
                case 7:
                    _instance._nameChangingParametr.text = "New GroupNum is: ";
                    return;  
            }
        }

        if (_instance.ListHum[_instance.ChoosenNumberOfHuman] is Employer ||
            _instance.ListHum[_instance.ChoosenNumberOfHuman] is Driver )
        {
            switch (_instance.ChoosenNumberOfParam)
            {
                case 5:
                    _instance._nameChangingParametr.text = "New Organization is: ";
                    return;
                case 6:
                    _instance._nameChangingParametr.text = "New WorkPay is: ";
                    return;
                case 7:
                    _instance._nameChangingParametr.text = "New WorkExp is: ";
                    return;
            }
        }

        if (_instance.ListHum[_instance.ChoosenNumberOfHuman] is Driver )
        {
            switch (_instance.ChoosenNumberOfParam)
            {
                case 8:
                    _instance._nameChangingParametr.text = "New CarBrand is: ";
                    return;
                case 9:
                    _instance._nameChangingParametr.text = "New CarModel is: ";
                    return; 
            }
        }
    }

    private void NewParameterFormat()
    {
        NewParameterValue.onEndEdit.RemoveAllListeners();
        NewParameterValue.onValueChanged.RemoveAllListeners();
        
        if (_instance.ChoosenNumberOfParam == 4)
            NewParameterValue.onEndEdit.AddListener(OnInputEndEdit);
        else
            NewParameterValue.onValueChanged.AddListener(OnValueChange);
    }
    
    private void OnInputEndEdit(string str)
    {
        NewParameterValue.contentType = TMP_InputField.ContentType.Standard;
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            NewParameterValue.text = "";
    }
    
    private void OnValueChange(string str)
    {
        if (_instance.ChoosenNumberOfParam < 4 || _instance.ChoosenNumberOfParam == 5 ||
            _instance.ChoosenNumberOfParam >= 8 )
            NewParameterValue.contentType = TMP_InputField.ContentType.Name;

        if (_instance.ChoosenNumberOfParam == 6 || _instance.ChoosenNumberOfParam == 7 )
            NewParameterValue.contentType = TMP_InputField.ContentType.IntegerNumber;
    }

    public static void CloseErrorWindow() => _instance.ErrorWindow.SetActive(false);

    private void CloseProgram() => Application.Quit();
}
