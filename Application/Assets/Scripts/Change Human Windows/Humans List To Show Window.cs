using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ListHumansForShowingWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private Button _save;
    private string _chosenNumber;

    public void SaveInformation()
    {
        if (_input.text != "")
        {
            if (int.Parse(_input.text) <= ViewManager._instance.ListHum.Count && int.Parse(_input.text) > 0)
            {
                _chosenNumber = new string(_input.text);
                ViewManager._instance.ChoosenNumberOfHuman = int.Parse(_chosenNumber) - 1;
                ViewManager._instance.ToNextWindow();
                CleanTextVariables();
                ViewManager._instance.ToNextWindowButton.gameObject.SetActive(true);
            }
            else
            {
                ViewManager._instance.ErrorWindow.SetActive(true);
            }
        }
    }

    public override void Initialize()
    {
        _save.onClick.AddListener(SaveInformation);
    }
    
    private void CleanTextVariables()
    {
        _input.text = "";
    }
}
