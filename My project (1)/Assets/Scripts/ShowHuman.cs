using UnityEngine;
using TMPro;

public class ShowHuman : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void Start()
    {
        ShowHum();
    }

    private void ShowHum()
    {
        if ( MemoryScript.showHumanNumber != "")
            text.text = $"{MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1]}";
        MemoryScript.showHumanNumber = "";
    }
}
