using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public abstract class AddHumanWindow : ViewMethods
{
    [SerializeField]protected TMP_InputField HumanName;
    [SerializeField]protected TMP_InputField HumanLName;
    [SerializeField]protected TMP_InputField HumanPatronymic;
    [SerializeField]protected TMP_InputField HumanBirthday;
    [SerializeField]protected Button SaveButton;
    public override void Initialize()
    {
        CleanTextVariables();
    }

    protected virtual void SaveInformation(Human hum)
    {
        ApplicationData.AppData.ListHum.Add(hum);
        ViewManager.Instance.GetView<AddMenuWindow>().SetParams();
        ViewManager.Instance.ToMainMenu();
    }
    
    private void OnInputEndEdit(string str)
    {
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            HumanBirthday.text = "";
    }

    protected void SettingFormatBirthday()
    {
        HumanBirthday.onEndEdit.AddListener(OnInputEndEdit);
    }
    
    public virtual bool CheckNullOrEmpty()
    {
        if (!string.IsNullOrEmpty(HumanName.text) && !string.IsNullOrEmpty(HumanLName.text) &&
            !string.IsNullOrEmpty(HumanPatronymic.text) && !string.IsNullOrEmpty(HumanBirthday.text))
            return false;
        else
            return true;
    }

    protected virtual void CleanTextVariables()
    {
        HumanName.text = "";
        HumanLName.text = "";
        HumanPatronymic.text = "";
        HumanBirthday.text = "";
    }
}
