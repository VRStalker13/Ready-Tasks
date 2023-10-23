using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class AddingHumanView : View
{
    [SerializeField] public TMP_InputField HumanName;
    [SerializeField] public TMP_InputField HumanLName;
    [SerializeField] public TMP_InputField HumanPatronymic;
    [SerializeField] public TMP_InputField HumanBirthday;
    [SerializeField] public Button Save;

    public override void Initialize()
    {
        HumanBirthday.onEndEdit.AddListener(OnInputEndEdit);
    }

    public virtual void SaveInformation(Human hum)
    {
        ViewManager._instance.ListHum.Add(hum);
        AddingMenuWindow.SetVisible(true);
        ViewManager._instance.ToMainMenu();
    }
    
    private void OnInputEndEdit(string str)
    {
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            HumanBirthday.text = "";
    }

    public virtual void CleanTextVariables()
    {
        HumanName.text = "";
        HumanLName.text = "";
        HumanPatronymic.text = "";
        HumanBirthday.text = "";
    }
}
