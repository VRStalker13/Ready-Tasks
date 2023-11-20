using UnityEngine;
using TMPro;

public class HumansInformationWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI HumansInformationText; //Информация обо всех людях

    public override void Initialize() => HumansInformationText.text = "";
    
    public override void SetParams()
    {
        var text = "List of all Humans:" + "\n---------------------";
        if (ApplicationData.AppData.ListHum.Count > 0)
        {
            foreach (var hum in ApplicationData.AppData.ListHum)
                text =$"{text}\n{hum}\n---------------------\n";
        }
        
        HumansInformationText.text = text; 
    }
}
