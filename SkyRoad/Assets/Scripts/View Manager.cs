using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private ViewMethods[] _views;// Массив всех экранов приложения
    [SerializeField] private Texture2D _cursorTexture;
        
    public static ViewManager Instance;
    
    private ViewMethods _currentView;// Текущее окно
    //public GameMusic Music;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public GameObject MenuCamera;
    public GameObject GameCamera;
    

    private void Awake() => Instance = this;
    
    private void Start()
    {
        Initialize();
        Instance.GetView<MainMenuBackgroundWindow>().Show();
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        Show<GameComicsWindow>();
    }

    private void Initialize()
    {
        foreach (var view in Instance._views)
        {
            view.Show();
            view.Hide();
        }
    }

    public void ActivateMenuCamera(bool isTrue)
    {
        GameCamera.SetActive(!isTrue);
        MenuCamera.SetActive(isTrue);
    }
    
    public void Show<T>(bool hide = true) where T : ViewMethods
    {
        for (var i = 0; i < Instance._views.Length; i++)
        {
            if (Instance._views[i] is T)
            {
                if (Instance._currentView != null && hide)
                    Instance._currentView.Hide();

                Instance._views[i].Show();
                Instance._views[i].SetParams();
                
                if(hide)
                    Instance._currentView = Instance._views[i];
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
}
