using UnityEngine;
using UnityEngine.UI;

public class AddMenuWindow : View
{
    [SerializeField] private Button _addStudent;
    [SerializeField] private Button _addEmployee;
    [SerializeField] private Button _addDriver;
    private Button[] _buttons;
    
    public override void Initialize()
    {
        _buttons = new[] {_addStudent,_addEmployee,_addDriver};
        _buttons[0].onClick.AddListener(() => ViewManager.s_instance.Show<AddStudentView>(false));
        _buttons[1].onClick.AddListener(() => ViewManager.s_instance.Show<AddEmployeeView>(false));
        _buttons[2].onClick.AddListener(() => ViewManager.s_instance.Show<AddDriverView>(false));
        
        foreach (var button in _buttons)
            button.onClick.AddListener(() => SetVisible(false));

        ViewManager.s_instance._addMenuButtons = _buttons;
    }

    public static void SetVisible(bool isVisible)
    {
        foreach (var button in ViewManager.s_instance._addMenuButtons)
            button.interactable = isVisible;
    }
}
