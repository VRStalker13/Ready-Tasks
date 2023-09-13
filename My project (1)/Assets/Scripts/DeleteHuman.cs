using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DeleteHuman : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    private string _chosenNumber;
    
    void Start()
    {
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
        {
            _save.interactable = false;
        }
        if(int.Parse(_input.text) <= MemoryScript.listHum.Count && int.Parse(_input.text) > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    public void SaveInformation()
    {
        _chosenNumber = new string(_input.text);
        MemoryScript.listHum.RemoveAt(int.Parse(_chosenNumber) - 1);
        ButtonsScript.ToStartMenu();
    }
}
