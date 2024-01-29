using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private ViewMethods[] _views; // Массив всех экранов приложения

    public static ViewManager Instance;

    private ViewMethods _currentView; // Текущее окно

    private void Awake() => Instance = this;

    private void Start()
    {
        Instance.GetView<MainMenuBackgroundWindow>().Show();
        Show<GameComicsWindow>();
    }

    public void Show<T>(bool hide = true) where T : ViewMethods
    {
        foreach (var view in Instance._views)
        {
            if (view is not T) continue;

            if (Instance._currentView != null && hide)
                Instance._currentView.Hide();

            view.Show();
            view.SetParams();

            if (hide)
                Instance._currentView = view;
        }
    }

    public ViewMethods GetView<T>()
    {
        foreach (var view in Instance._views)
        {
            if (view is T)
                return view;
        }

        return null;
    }
}