public class HumansInformationWindow : View
{
    public static string ShowHumans()
    {            
        var text = "List of all Humans:" + "\n---------------------";
            
        foreach (var hum in ViewManager._instance.ListHum)
            text =$"{text}\n{hum}\n---------------------\n";

        return text;
    }

    public override void Initialize(){}
}
