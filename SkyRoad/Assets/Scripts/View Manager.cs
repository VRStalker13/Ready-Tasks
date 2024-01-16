using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private ViewMethods[] _views;// Массив всех экранов приложения
        
    public static ViewManager Instance;
    
    private ViewMethods _currentView;// Текущее окно

    private void Awake() => Instance = this;
    
    private void Start()
    {
        Instance.GetView<MainMenuBackgroundWindow>().Show();
        Show<GameComicsWindow>();
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
