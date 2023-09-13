using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoseParamNum : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    [SerializeField] private Button _nextScene;
    private string _chosenNumber;
    private int _maxValue = new int();
    
    void Start()
    {
        _nextScene.interactable = false;
        _save.interactable = false;
        _listChoose.text = MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1].ListChanges();

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Student)
            _maxValue = 7;

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Employee)
            _maxValue = 7;

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Driver)
            _maxValue = 9;
    }
    
    void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (_input.text.Length < 1)
        {
            _save.interactable = false;
        }
        if(int.Parse(_input.text) <= _maxValue && int.Parse(_input.text) > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    public void SaveInformation()
    {
        MemoryScript.changeParamNumer = _input.text;
        _nextScene.interactable = true;
    }
}
