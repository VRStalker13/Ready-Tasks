using UnityEngine;
using TMPro;

public class ShowAllHumans : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _humansInformation;
    // Start is called before the first frame update
    void Start()
    {
        _humansInformation.text = ShowHumans();
    }

    public static string ShowHumans()
    {            
        var text = "List of all Humans:" + "\n---------------------";
            
        foreach (var hum in MemoryScript.listHum)
            text =$"{text}\n{hum}\n---------------------\n";

        return text;
    }
}
