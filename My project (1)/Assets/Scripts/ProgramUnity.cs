using UnityEngine;

public class ProgramUnity : MonoBehaviour
{
    public static string ShowListHumans()
    {
        var count = MemoryScript.ListHum.Count;
        var text = "Human List:\n";
            
        for (var i = 0; i < count; i++)            
            text = $"{text}\n{i + 1}. {MemoryScript.ListHum[i].FirstName} {MemoryScript.ListHum[i].LastName} {MemoryScript.ListHum[i].Patronymic}"; 
            
        return text;
    }
}
