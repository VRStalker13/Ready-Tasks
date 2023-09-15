using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseParamNum : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    [SerializeField] private Button _nextScene;
    private int _maxValue;
    
    private void Start()
    {
        _nextScene.interactable = false;
        _save.interactable = false;
        _listChoose.text = MemoryScript.ListHum[int.Parse(MemoryScript.ShowHumanNumber) - 1].ListChanges();

        if (MemoryScript.ListHum[int.Parse(MemoryScript.ShowHumanNumber) - 1] is Student)
            _maxValue = 7;

        if (MemoryScript.ListHum[int.Parse(MemoryScript.ShowHumanNumber) - 1] is Employer)
            _maxValue = 7;

        if (MemoryScript.ListHum[int.Parse(MemoryScript.ShowHumanNumber) - 1] is Driver)
            _maxValue = 9;
    }
    
    private void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (_input.text.Length < 1)
            _save.interactable = false;
        
        if(int.Parse(_input.text) <= _maxValue && int.Parse(_input.text) > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    public void SaveInformation()
    {
        MemoryScript.ChangeParamNumber = _input.text;
        _nextScene.interactable = true;
    }
}
