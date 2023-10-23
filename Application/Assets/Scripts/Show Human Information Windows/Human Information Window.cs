using UnityEngine;
using TMPro;

public class HumanInformationWindow : View
{
    public static string ShowHuman()
    {
        return $"{ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman]}";
    }

    public override void Initialize()
    {
        
    }
}
