using UnityEngine;
using UnityEngine.UI;

public class AddMenuWindow : ViewMethods
{
    [SerializeField] private Button _addStudent;
    [SerializeField] private Button _addEmployee;
    [SerializeField] private Button _addDriver;
    private Button[] _buttons;
    
    public override void Initialize()
    {
        _buttons = new[] {_addStudent,_addEmployee,_addDriver};
        _buttons[0].onClick.AddListener(() => ViewManager.Instance.Show<AddStudentWindow>(false));
        _buttons[0].onClick.AddListener(() => ViewManager.Instance.GetView<AddStudentWindow>().Initialize());
        
        _buttons[1].onClick.AddListener(() => ViewManager.Instance.Show<AddEmployeeWindow>(false));
        _buttons[1].onClick.AddListener(() => ViewManager.Instance.GetView<AddEmployeeWindow>().Initialize());
        
        _buttons[2].onClick.AddListener(() => ViewManager.Instance.Show<AddDriverWindow>(false));
        _buttons[2].onClick.AddListener(() => ViewManager.Instance.GetView<AddDriverWindow>().Initialize());
        
        
        foreach (var button in _buttons)
            button.onClick.AddListener(() => SetVisible(false));
    }

    public override void SetParams()
    {
        SetVisible(true);
    }

    public void SetVisible(bool isVisible)
    {
        foreach (var button in _buttons)
            button.interactable = isVisible;
    }
}
