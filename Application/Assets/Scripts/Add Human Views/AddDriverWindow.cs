using System;
using UnityEngine;
using TMPro;

public class AddDriverWindow : AddHumanWindow
{
    [SerializeField] private TMP_InputField _driverOrgName;
    [SerializeField] private TMP_InputField _driverWorkPay;
    [SerializeField] private TMP_InputField _driverWorkExp;
    [SerializeField] private TMP_InputField _driverBrandCar;
    [SerializeField] private TMP_InputField _driverModelCar;

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
            Human hum = new Driver(HumanName.text,HumanLName.text,HumanPatronymic.text,
                DateTime.Parse(HumanBirthday.text),_driverOrgName.text,_driverWorkPay.text,
                _driverWorkExp.text,_driverBrandCar.text,_driverModelCar.text);
            CleanTextVariables();
            SaveInformation(hum);
        }
        else
        {
            ViewManager.Instance.ErrorWindow.SetActive(true);
        }
    }
    
    public override bool CheckNullOrEmpty()
    {
        if (!base.CheckNullOrEmpty() && !string.IsNullOrEmpty(_driverOrgName.text) && 
            !string.IsNullOrEmpty(_driverWorkPay.text) && !string.IsNullOrEmpty(_driverWorkExp.text) &&
            !string.IsNullOrEmpty(_driverBrandCar.text) && !string.IsNullOrEmpty(_driverModelCar.text))
            return false;
        else
            return true;
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
