using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitСonfirmationWindow : ViewMethods
{
    [SerializeField] private Button _noButton;
    [SerializeField] private Button _yesButton;
    
    void Start()
    {
        SetButtonsListeners();
    }

    private void SetButtonsListeners()
    {
        _yesButton.onClick.AddListener(() => Application.Quit());
        _noButton.onClick.AddListener(() => ViewManager.Instance.GetView<ExitСonfirmationWindow>().Hide());
        AddOnPointerEnter(new []{_noButton,_yesButton},EventTriggerType.PointerEnter,(data) => MusicManager.Music.PlaySound("Buttons Music",true));
    }
}
