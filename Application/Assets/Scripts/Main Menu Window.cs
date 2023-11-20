using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : ViewMethods
{
    [SerializeField] private Button _addHumanButton;
    [SerializeField] private Button _deleteHumanButton;
    [SerializeField] private Button _showHumanButton;
    [SerializeField] private Button _showHumansButton;
    [SerializeField] private Button _changeHumanButton;

    public override void Initialize()
    {
        SetParams();
    }

    public override void SetParams()
    {
        _addHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<AddMenuWindow>());
        _addHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumansButton.onClick.AddListener(() => ViewManager.Instance.Show<HumansInformationWindow>());
        _showHumansButton.onClick.AddListener(() =>
            ViewManager.Instance.ShowInformationOnView(ViewManager.Instance.GetView<HumansInformationWindow>()));
        _showHumansButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _deleteHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForDeletingWindow>());
        _deleteHumanButton.onClick.AddListener(() => 
            ViewManager.Instance.ShowInformationOnView(ViewManager.Instance.GetView<ListHumansForDeletingWindow>()));
        _deleteHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
        
        _showHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForShowingWindow>());
        _showHumanButton.onClick.AddListener(() =>  
            ViewManager.Instance.ShowInformationOnView(ViewManager.Instance.GetView<ListHumansForShowingWindow>()));
        _showHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));

        _changeHumanButton.onClick.AddListener(() => ViewManager.Instance.Show<ListHumansForChangingWindow>());
        _changeHumanButton.onClick.AddListener(() => 
            ViewManager.Instance.ShowInformationOnView(ViewManager.Instance.GetView<ListHumansForChangingWindow>()));
        _changeHumanButton.onClick.AddListener(() => ViewManager.Instance.ToMainMenuButton.gameObject.SetActive(true));
    }
}
