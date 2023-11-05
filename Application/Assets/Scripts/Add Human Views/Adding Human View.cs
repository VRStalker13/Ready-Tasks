using System;
using System.Globalization;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public abstract class AddingHumanView : View
{
    [SerializeField]protected TMP_InputField _humanName;
    [SerializeField]protected TMP_InputField _humanLName;
    [SerializeField]protected TMP_InputField _humanPatronymic;
    [SerializeField]protected TMP_InputField _humanBirthday;
    [SerializeField]protected Button _saveButton;

    public override void Initialize()
    {
        CleanTextVariables();
    }

    protected virtual void SaveInformation(Human hum)
    {
        ApplicationData.AppData.ListHum.Add(hum);
        AddingMenuWindow.AddingMenu.SetVisible(true);
        ViewManager.Instance.ToMainMenu();
    }
    
    private void OnInputEndEdit(string str)
    {
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            _humanBirthday.text = "";
    }

    protected void SettingFormatBirthday()
    {
        _humanBirthday.onEndEdit.AddListener(OnInputEndEdit);
    }

    protected virtual void CleanTextVariables()
    {
        _humanName.text = "";
        _humanLName.text = "";
        _humanPatronymic.text = "";
        _humanBirthday.text = "";
    }
}
