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
        _addHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<AddingMenuWindow>());
        _addHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumansButton.onClick.AddListener(() => ViewManager.Instance.Show<HumansInformationWindow>());
        _showHumansButton.onClick.AddListener(() => HumansInformationWindow.HumansInformation.ShowHumans());
        _showHumansButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _deleteHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForDeletingWindow>());
        _deleteHumanButton.onClick.AddListener(() => ListHumansForDeletingWindow.ListHumansForDel.ShowListHumans());
        _deleteHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForShowingWindow>());
        _showHumanButton.onClick.AddListener(() => ListHumansForShowingWindow.ListHumansForShowing.ShowListHumans());
        _showHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));

        _changeHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForChangingWindow>());
        _changeHumanButton.onClick.AddListener(() => ListHumansForChangingWindow.ListHumansForChanging.ShowListHumans());
        _changeHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
    }
}
