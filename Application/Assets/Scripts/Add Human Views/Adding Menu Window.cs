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
        _buttons[0].onClick.AddListener(() => ViewManager._instance.Show<AddingStudentView>(false));
        _buttons[1].onClick.AddListener(() => ViewManager._instance.Show<AddingEmployeeView>(false));
        _buttons[2].onClick.AddListener(() => ViewManager._instance.Show<AddingDriverView>(false));
        
        foreach (var button in _buttons)
            button.onClick.AddListener(() => SetVisible(false));

        ViewManager._instance.AddMenuButtons = _buttons;
    }

    public static void SetVisible(bool isVisible)
    {
        foreach (var button in ViewManager._instance.AddMenuButtons)
            button.interactable = isVisible;
    }
}
