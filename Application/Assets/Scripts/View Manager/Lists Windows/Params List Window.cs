using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParamsListWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    private int _maxValue;

    private void Update()
    {
        if (ViewManager.s_instance.ListHum.Count > 0)
        {
            if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Student)
                _maxValue = 7;
    
            if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Employer)
                _maxValue = 7;
    
            if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Driver)
                _maxValue = 9;
        }

        ActivateSave();
        _listChoose.text = ViewManager.s_instance._currentView is ParamsListWindow? 
            ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman].ListChanges() : "";
    }

    private void ActivateSave()
    {
        if (_input.text.Length < 1)
            _save.interactable = false;
        
        if (_input.text != "")
        {
            if (int.Parse(_input.text) <= _maxValue && int.Parse(_input.text) > 0)
                _save.interactable = true;
            else
                _save.interactable = false;
        }
    }

    public void SaveInformation()
    {
        ViewManager.s_instance._choosenNumberOfParam = int.Parse(_input.text);
        ViewManager.s_instance.ToNextWindow();
        CleanTextVariables();
        ViewManager.s_instance._toNextWindowButton.gameObject.SetActive(true);
    }

    public override void Initialize()
    {
        _save.interactable = false;
        _save.onClick.AddListener(SaveInformation);
        _input.text = "";
    }
    
    private void CleanTextVariables()
    {
        _input.text = "";
    }
}
