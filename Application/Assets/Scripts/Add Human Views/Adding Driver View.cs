using System;
using UnityEngine;
using TMPro;

public class AddingDriverView : AddingHumanView
{
    [SerializeField] private TMP_InputField _driverOrgName;
    [SerializeField] private TMP_InputField _driverWorkPay;
    [SerializeField] private TMP_InputField _driverWorkExp;
    [SerializeField] private TMP_InputField _driverBrandCar;
    [SerializeField] private TMP_InputField _driverModelCar;

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
            !string.IsNullOrEmpty(_humanPatronymic.text) && !string.IsNullOrEmpty(_driverOrgName.text) && 
            !string.IsNullOrEmpty(_driverWorkPay.text) && !string.IsNullOrEmpty(_driverWorkExp.text) &&
            !string.IsNullOrEmpty(_driverBrandCar.text) && !string.IsNullOrEmpty(_driverModelCar.text) &&
            !string.IsNullOrEmpty(_humanBirthday.text))
        {
            Human hum = new Driver(_humanName.text,_humanLName.text,_humanPatronymic.text,
                DateTime.Parse(_humanBirthday.text),_driverOrgName.text,_driverWorkPay.text,
                _driverWorkExp.text,_driverBrandCar.text,_driverModelCar.text);
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
        _driverOrgName.text = "";
        _driverWorkPay.text = "";
        _driverWorkExp.text = "";
        _driverBrandCar.text = "";
        _driverModelCar.text = "";
    }
}
