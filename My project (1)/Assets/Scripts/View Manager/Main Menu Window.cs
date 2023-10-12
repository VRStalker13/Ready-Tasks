using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : View
{
    [SerializeField] private Button _addHumanButton;
    [SerializeField] private Button _deleteHumanButton;
    [SerializeField] private Button _showHumanButton;
    [SerializeField] private Button _showHumansButton;
    [SerializeField] private Button _changeHumanButton;

    public override void Initialize()
    {
        _addHumanButton.onClick.AddListener(() => ViewManager.s_instance.Show<AddMenuWindow>());
        _deleteHumanButton.onClick.AddListener(() => ViewManager.s_instance.Show<HumansListToDeleteWindow>());
        _showHumanButton.onClick.AddListener(() => ViewManager.s_instance.Show<HumansListToShowWindow>());
        _showHumansButton.onClick.AddListener(() => ViewManager.s_instance.Show<HumansInformationWindow>());
        _changeHumanButton.onClick.AddListener(() => ViewManager.s_instance.Show<HumansListToChangeWindow>());
    }
}
