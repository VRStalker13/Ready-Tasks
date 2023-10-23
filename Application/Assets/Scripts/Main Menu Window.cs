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
        _addHumanButton.onClick.AddListener(() => ViewManager._instance.Show<AddingMenuWindow>());
        _addHumanButton.onClick.AddListener(() => ViewManager._instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumansButton.onClick.AddListener(() => ViewManager._instance.Show<HumansInformationWindow>());
        _showHumansButton.onClick.AddListener(() => ViewManager._instance.HumansInformation.text 
            = HumansInformationWindow.ShowHumans());
        _showHumansButton.onClick.AddListener(() => ViewManager._instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _deleteHumanButton.onClick.AddListener(() => ViewManager._instance.Show<ListHumansForDeletingWindow>());
        _deleteHumanButton.onClick.AddListener(() => ViewManager._instance.ListHumansForDeleting.text 
            = ViewManager._instance.ShowListHumans());
        _deleteHumanButton.onClick.AddListener(() => ViewManager._instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumanButton.onClick.AddListener(() => ViewManager._instance.Show<ListHumansForShowingWindow>());
        _showHumanButton.onClick.AddListener(() => ViewManager._instance.ListHumans.text 
            = ViewManager._instance.ShowListHumans());
        _showHumanButton.onClick.AddListener(() => ViewManager._instance.ToMainMenuButton.gameObject.SetActive(true));

        _changeHumanButton.onClick.AddListener(() => ViewManager._instance.Show<ListHumansForChangingWindow>());
        _changeHumanButton.onClick.AddListener(() => ViewManager._instance.ListHumansForChanging.text 
            = ViewManager._instance.ShowListHumans());
        _changeHumanButton.onClick.AddListener(() => ViewManager._instance.ToMainMenuButton.gameObject.SetActive(true));
    }
}
