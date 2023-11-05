using UnityEngine;
using TMPro;

public class HumansInformationWindow : View
{
    public static HumansInformationWindow HumansInformation;
    
    [SerializeField] private TextMeshProUGUI HumansInformationText; //Информация обо всех людях

    private void Awake() => HumansInformation = this;
    
    public void ShowHumans()
    {            
        var text = "List of all Humans:" + "\n---------------------";
        if (ApplicationData.AppData.ListHum.Count > 0)
        {
            foreach (var hum in ApplicationData.AppData.ListHum)
                text =$"{text}\n{hum}\n---------------------\n";
        }
        
        HumansInformationText.text = text;
    }

    public override void Initialize() => HumansInformationText.text = "";
}
