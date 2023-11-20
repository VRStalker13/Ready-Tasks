using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    [SerializeField] public GameObject ErrorWindow; // Окно ошибки
    [SerializeField] private ViewMethods _startingView;// Начальный экран
    [SerializeField] private ViewMethods[] _views;// Массив всех экранов приложения
    [SerializeField] private Button _closeProgramButton;// Кнопка закрытия приложения
    
    public static ViewManager Instance;
    
    public Button ToMainMenuButton;// Кнопка переводящая на начальное меню
    public Button ToNextWindowButton;// Кнопка переключения на следующее окно
    public Button CloseErrorWindowButton; // Кнопка закрытия окна с ошибкой
    
    public ViewMethods CurrentView;// Текущее окно
        
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

    public ViewMethods GetView<T>()
    {
        ViewMethods requiredWindow = null;
        
        for (var i = 0; i < Instance._views.Length; i++)
            if (Instance._views[i] is T)
                requiredWindow = Instance._views[i];

        return requiredWindow;
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
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.GetView<ListParamsForChangingWindow>().SetParams());
        }

        if (Instance.CurrentView is ListHumansForShowingWindow)
        {
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.Show<HumanInformationWindow>());
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.GetView<HumanInformationWindow>().SetParams());
        }

        if (Instance.CurrentView is ListParamsForChangingWindow)
        {
            Instance.ToNextWindowButton.onClick.AddListener(() => Instance.Show<EditHumanWindow>());
            Instance.ToNextWindowButton.onClick.AddListener(Instance.GetView<EditHumanWindow>().SetParams);
        }
        
        Instance.ToNextWindowButton.onClick.AddListener(() => 
            Instance.ToNextWindowButton.gameObject.SetActive(false));
    }

    public void ToMainMenu()
    {
        Instance.ToMainMenuButton.gameObject.SetActive(false);
        Instance.GetView<AddMenuWindow>().SetParams();
        Show<MainMenuWindow>();
        HideAllViews();
    }

    private void HideAllViews()
    {
        foreach (var view in Instance._views)
            if(view is not MainMenuWindow)
                view.Hide();
    }

    public void ShowInformationOnView(ViewMethods view)
    {
        view.SetParams();
    }

    private void CloseErrorWindow() => Instance.ErrorWindow.SetActive(false);

    private void CloseProgram() => Application.Quit();
}
