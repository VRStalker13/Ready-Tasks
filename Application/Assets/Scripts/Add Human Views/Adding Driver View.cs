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

    public void SaveInformation()
    {
        if (HumanName.text != "" && HumanLName.text != "" && HumanPatronymic.text != "" && 
            _driverOrgName.text != "" && _driverWorkPay.text != "" && _driverWorkExp.text != "" &&
            _driverBrandCar.text != "" && _driverModelCar.text != "" && HumanBirthday.text != "")
        {
            Human hum = new Driver(HumanName.text,HumanLName.text,HumanPatronymic.text,
                DateTime.Parse(HumanBirthday.text),_driverOrgName.text,_driverWorkPay.text,
                _driverWorkExp.text,_driverBrandCar.text,_driverModelCar.text);
            CleanTextVariables();
            base.SaveInformation(hum);
        }
        else
        {
            ViewManager._instance.ErrorWindow.SetActive(true);
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        Save.onClick.AddListener(SaveInformation);
    }

    public override void CleanTextVariables()
    {
        base.CleanTextVariables();
        _driverOrgName.text = "";
        _driverWorkPay.text = "";
        _driverWorkExp.text = "";
        _driverBrandCar.text = "";
        _driverModelCar.text = "";
    }
}
