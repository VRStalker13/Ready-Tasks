using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    [SerializeField] public GameObject ErrorWindow; // Окно ошибки
    [SerializeField] private View _startingView;// Начальный экран
    [SerializeField] private View[] _views;// Массив всех экранов приложения
    [SerializeField] private Button _closeProgramButton;// Кнопка закрытия приложения
    
    public static ViewManager Instance;
    
    public Button ToMainMenuButton;// Кнопка переводящая на начальное меню
    public Button ToNextWindowButton;// Кнопка переключения на следующее окно
    public Button CloseErrorWindowButton; // Кнопка закрытия окна с ошибкой
    
    public View CurrentView;// Текущее окно
    public ListHumansForChangingWindow ListHumsForChangingWindowObject ;
    public AddingDriverView AddingDriverViewObject;
    public AddingEmployeeView AddingEmployeeViewObject;
    public AddingStudentView AddingStudentViewObject;
    public HumansInformationWindow HumansInformationWindowObject;
    public ListHumansForDeletingWindow ListHumansForDeletingWindowObject;
    public ListHumansForShowingWindow ListHumansForShowingWindowObject;
    public HumanInformationWindow HumanInformationWindowObject;
    public ListParamsForChangingWindow ListParamsForChangingWindowObject;
    public ProcessChangingHumanWindow ProcessChangingHumanWindowObject;
    public AddingMenuWindow AddingMenuWindowObject;
        
    public void Show<T>(bool hide = true) where T : View
    {
        for (var i = 0; i < Instance._views.Length; i++)
        {
            if (Instance._views[i] is T)
            {
                if (Instance.CurrentView != null && hide)
                    Instance.CurrentView.Hide();

                Instance._views[i].Show();
                
                if(hide)
                    Instance.CurrentView = Instance._views[i];
            }
        }
    }

    private void Awake() => Instance = this;
    
    private void Start()
    {
        Initialize();
        
        if (Instance._startingView != null)
            Show<MainMenuWindow>();
    }

    private void Initialize()
    {
        foreach (var view in Instance._views)
        {
            view.Show();
            view.Initialize();
            view.Hide();
        }
        Instance.ToMainMenuButton.gameObject.SetActive(false);
        Instance.ToMainMenuButton.onClick.AddListener(ToMainMenu);
        Instance._closeProgramButton.onClick.AddListener(CloseProgram);
        Instance.CloseErrorWindowButton.onClick.AddListener(CloseErrorWindow);
    }

    public void ToNextWindow()
    {
        Instance.ToNextWindowButton.onClick.RemoveAllListeners();

        if (Instance.CurrentView is ListHumansForChangingWindow)
        {
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.Show<ListParamsForChangingWindow>());
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.ListParamsForChangingWindowObject.ShowList());
        }

        if (Instance.CurrentView is ListHumansForShowingWindow)
        {
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.Show<HumanInformationWindow>());
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.HumanInformationWindowObject.ShowHuman());
        }

        if (Instance.CurrentView is ListParamsForChangingWindow)
        {
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.Show<ProcessChangingHumanWindow>());
            Instance.ToNextWindowButton.onClick.AddListener(Instance.ProcessChangingHumanWindowObject.SetNewParameterFormat);
            Instance.ToNextWindowButton.onClick.AddListener(Instance.ProcessChangingHumanWindowObject.SetNewParameterName);
        }
        
        Instance.ToNextWindowButton.onClick.AddListener(() => 
            Instance.ToNextWindowButton.gameObject.SetActive(false));
    }

    public void ToMainMenu()
    {
        Instance.ToMainMenuButton.gameObject.SetActive(false);
        Instance.AddingMenuWindowObject.SetVisible(true);
        Show<MainMenuWindow>();
        HideAllViews();
    }

    private void HideAllViews()
    {
        foreach (var view in Instance._views)
            if(view is not MainMenuWindow)
                view.Hide();
    }

    public void ShowInformationOnView(View view)
    {
        view.ShowList();
    }

    private void CloseErrorWindow() => Instance.ErrorWindow.SetActive(false);

    private void CloseProgram() => Application.Quit();
}