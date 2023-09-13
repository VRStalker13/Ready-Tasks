using UnityEngine;

public class ProgramUnity : MonoBehaviour
{
    public static string ShowListHumans()
    {
        var count = MemoryScript.listHum.Count;
        string text = "Human List:\n";
            
        for (var i = 0; i < count; i++)            
            text = $"{text}\n{i + 1}. {MemoryScript.listHum[i].FirstName} {MemoryScript.listHum[i].LastName} {MemoryScript.listHum[i].Patronymic}"; 
            
        return text;
    }
}
