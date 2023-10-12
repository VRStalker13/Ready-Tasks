using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class HumanInformationWindow : View
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Update()
    {
        ShowHum();
    }

    private void ShowHum()
    {
        if ( ViewManager.s_instance._currentView is HumanInformationWindow)
            _text.text = $"{ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman]}";
    }

    public override void Initialize()
    {
        
    }
}
