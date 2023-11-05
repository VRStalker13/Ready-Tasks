using UnityEngine;
using TMPro;

public class HumanInformationWindow : View
{
    public static HumanInformationWindow HumanInform;
    
    [SerializeField] private TextMeshProUGUI _humanInformation;
    
    private void Awake() => HumanInform = this;
    
    public void ShowHuman()
    {
        _humanInformation.text = $"{ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman]}";
    }

    public override void Initialize()
    {
        _humanInformation.text = "";
    }
}
