using UnityEngine;
using TMPro;

public class HumanInformationWindow : View
{
    [SerializeField] private TextMeshProUGUI _humanInformation;
    
    public void ShowHuman()
    {
        _humanInformation.text = $"{ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman]}";
    }

    public override void Initialize()
    {
        _humanInformation.text = "";
    }
}
