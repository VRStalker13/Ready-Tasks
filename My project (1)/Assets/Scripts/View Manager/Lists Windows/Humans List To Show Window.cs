using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HumansListToShowWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _listChoose;
    [SerializeField] private Button _save;
    private string _chosenNumber;

    void Update()
    {
        ActivateSave();
        _listChoose.text = ViewManager.s_instance._currentView is HumansListToShowWindow? 
            ViewManager.s_instance.ShowListHumans() : "";
    }

    private void ActivateSave()
    {
        if (_input.text.Length < 1)
        {
            _save.interactable = false;
        }
            
        if (_input.text != "")
        {
            if (int.Parse(_input.text) <= ViewManager.s_instance.ListHum.Count && int.Parse(_input.text) > 0)
            {
                _save.interactable = true;
            }
            else
            {
                _save.interactable = false;
            }
        }
    }

    public void SaveInformation()
    {
        _chosenNumber = new string(_input.text);
        ViewManager.s_instance._choosenNumberOfHuman = int.Parse(_chosenNumber) - 1;
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
