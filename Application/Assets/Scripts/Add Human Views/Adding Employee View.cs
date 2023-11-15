using System;
using UnityEngine;
using TMPro;

public class AddingEmployeeView : AddingHumanView
{
    [SerializeField]private TMP_InputField _emplOrgName;
    [SerializeField]private TMP_InputField _emplWorkPay;
    [SerializeField]private TMP_InputField _emplWorkExp;
    
    private void Start()
    {
        SettingFormatBirthday();
        _saveButton.onClick.AddListener(SaveInformation);
    }
    
    public override void Initialize()
    {
        base.Initialize();
        CleanTextVariables();
    }

    private void SaveInformation()
    {
        if (!string.IsNullOrEmpty(_humanName.text) && !string.IsNullOrEmpty(_humanLName.text) &&
            !string.IsNullOrEmpty(_humanPatronymic.text) && !string.IsNullOrEmpty(_emplOrgName.text) && 
            !string.IsNullOrEmpty(_emplWorkPay.text) && !string.IsNullOrEmpty(_emplWorkExp.text) &&
            !string.IsNullOrEmpty(_humanBirthday.text))
        {
            Human hum = new Employer(_humanName.text, _humanLName.text, _humanPatronymic.text,
                DateTime.Parse(_humanBirthday.text), _emplOrgName.text, _emplWorkPay.text, _emplWorkExp.text);
            CleanTextVariables();
            SaveInformation(hum);
        }
        else
        {
            ViewManager.Instance.ErrorWindow.SetActive(true);
        }
    }

    protected override void CleanTextVariables()
    {
        base.CleanTextVariables();
        _emplOrgName.text = "";
        _emplWorkPay.text = "";
        _emplWorkExp.text = "";
    }
}
