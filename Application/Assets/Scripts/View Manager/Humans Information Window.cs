using System;
using UnityEngine;
using TMPro;

public class HumansInformationWindow : View
{
    [SerializeField] private TextMeshProUGUI _humansInformation;

    public string ShowHumans()
    {            
        var text = "List of all Humans:" + "\n---------------------";
            
        foreach (var hum in ViewManager.s_instance.ListHum)
            text =$"{text}\n{hum}\n---------------------\n";

        return text;
    }

    public void Update()
    {
        _humansInformation.text = ViewManager.s_instance._currentView is HumansInformationWindow? ShowHumans():"";
    }

    public override void Initialize(){}
}
