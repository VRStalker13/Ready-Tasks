using UnityEngine;
using TMPro;

public class HumanInformationWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _humanInformation;

    public override void Initialize()
    {
        _humanInformation.text = "";
    }

    public override void SetParams()
    {
        _humanInformation.text = $"{ApplicationData.AppData.ListHum[ApplicationData.AppData.ChosenNumberOfHuman]}";
    }
}
