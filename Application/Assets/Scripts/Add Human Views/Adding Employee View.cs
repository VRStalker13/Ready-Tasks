using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class AddingEmployeeView : AddingHumanView
{
    [SerializeField]private TMP_InputField _emplOrgName;
    [SerializeField]private TMP_InputField _emplWorkPay;
    [SerializeField]private TMP_InputField _emplWorkExp;
    
    public void SaveInformation()
    {
        if (HumanName.text != "" && HumanLName.text != "" && HumanPatronymic.text != "" &&
            _emplOrgName.text != "" && _emplWorkPay.text != "" && _emplWorkExp.text != "" &&
            HumanBirthday.text != "")
        {
            Human hum = new Employer(HumanName.text, HumanLName.text, HumanPatronymic.text,
                DateTime.Parse(HumanBirthday.text), _emplOrgName.text, _emplWorkPay.text, _emplWorkExp.text);
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
        _emplOrgName.text = "";
        _emplWorkPay.text = "";
        _emplWorkExp.text = "";
    }
}
