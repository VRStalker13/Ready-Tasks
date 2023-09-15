using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ShowHuman : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Start()
    {
        ShowHum();
    }

    private void ShowHum()
    {
        if ( MemoryScript.ShowHumanNumber != "")
            _text.text = $"{MemoryScript.ListHum[int.Parse(MemoryScript.ShowHumanNumber) - 1]}";
        
        MemoryScript.ShowHumanNumber = "";
    }
}
