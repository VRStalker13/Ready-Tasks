using UnityEngine;
using UnityEngine.UI;

public class AddingMenuWindow : View
{
    [SerializeField] private Button _addStudent;
    [SerializeField] private Button _addEmployee;
    [SerializeField] private Button _addDriver;
    private Button[] _buttons;
    
    public override void Initialize()
    {
        _buttons = new[] {_addStudent,_addEmployee,_addDriver};
        _buttons[0].onClick.AddListener(() => ViewManager.Instance.Show<AddingStudentView>(false));
        _buttons[0].onClick.AddListener(() => ViewManager.Instance.AddingStudentViewObject.Initialize());
        
        _buttons[1].onClick.AddListener(() => ViewManager.Instance.Show<AddingEmployeeView>(false));
        _buttons[1].onClick.AddListener(() => ViewManager.Instance.AddingEmployeeViewObject.Initialize());
        
        _buttons[2].onClick.AddListener(() => ViewManager.Instance.Show<AddingDriverView>(false));
        _buttons[2].onClick.AddListener(() => ViewManager.Instance.AddingDriverViewObject.Initialize());
        
        
        foreach (var button in _buttons)
            button.onClick.AddListener(() => SetVisible(false));
    }

    public void SetVisible(bool isVisible)
    {
        foreach (var button in _buttons)
            button.interactable = isVisible;
    }
}
