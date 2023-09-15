using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoseShowHuman : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    [SerializeField] private Button _nextScene;
    private string _chosenNumber;
    
    void Start()
    {
        _nextScene.interactable = false;
        _save.interactable = false;
        _listChoose.text = ProgramUnity.ShowListHumans();
    }
    
    void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (_input.text.Length < 1)
            _save.interactable = false;
        
        if(int.Parse(_input.text) <= MemoryScript.ListHum.Count && int.Parse(_input.text) > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    public void SaveInformation()
    {
        MemoryScript.ShowHumanNumber = _input.text;
        _nextScene.interactable = true;
    }
}
