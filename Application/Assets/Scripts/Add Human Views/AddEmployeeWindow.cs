using System;
using UnityEngine;
using TMPro;

public class AddEmployeeWindow : AddHumanWindow
{
    [SerializeField] private TMP_InputField _emplOrgName;
    [SerializeField] private TMP_InputField _emplWorkPay;
    [SerializeField] private TMP_InputField _emplWorkExp;
    
    private void Start()
    {
        SetParams();
    }
    
    public override void Initialize()
    {
        base.Initialize();
        CleanTextVariables();
    }

    public override void SetParams()
    {
        SettingFormatBirthday();
        SaveButton.onClick.AddListener(SaveInformation);
    }

    private void SaveInformation()
    {
        if (!CheckNullOrEmpty())
        {
            var hum = new Employer(HumanName.text, HumanLName.text, HumanPatronymic.text,
                DateTime.Parse(HumanBirthday.text), _emplOrgName.text, _emplWorkPay.text, _emplWorkExp.text);
            CleanTextVariables();
            SaveInformation(hum);
        }
        else
        {
            ViewManager.Instance.ErrorWindow.SetActive(true);
        }
    }

    protected override bool CheckNullOrEmpty()
    {
        return base.CheckNullOrEmpty() || string.IsNullOrEmpty(_emplOrgName.text) ||
               string.IsNullOrEmpty(_emplWorkPay.text) || string.IsNullOrEmpty(_emplWorkExp.text);
    }

    protected override void CleanTextVariables()
    {
        base.CleanTextVariables();
        _emplOrgName.text = "";
        _emplWorkPay.text = "";
        _emplWorkExp.text = "";
    }
}
