using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddEmployeer : MonoBehaviour
{
    [SerializeField]private TMP_InputField SetEmplName;
    [SerializeField]private TMP_InputField SetEmplLName;
    [SerializeField]private TMP_InputField SetEmplPatronumic;
    [SerializeField]private TMP_InputField SetEmplOrgName;
    [SerializeField]private TMP_InputField SetEmplWorkPay;
    [SerializeField]private TMP_InputField SetEmplWorkExp;
    [SerializeField]private TMP_InputField SetEmplBirthday;
    [SerializeField]private Button _save;

    public void Start()
    {
        _save.interactable = false;
    }

    public void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (SetEmplName.text != "" && SetEmplLName.text != "" &&
            SetEmplPatronumic.text != "" && SetEmplOrgName.text != "" &&
            SetEmplWorkPay.text != "" && SetEmplWorkExp.text != "" &&
            SetEmplBirthday.text != "")
            _save.interactable = true;
        else
            _save.interactable = false;
    }
    
    public void SaveInformation()
    {
        Human hum = new Employee(SetEmplName.text, SetEmplLName.text, SetEmplPatronumic.text,
            DateTime.Parse(SetEmplBirthday.text), SetEmplOrgName.text, SetEmplWorkPay.text, SetEmplWorkExp.text);
        MemoryScript.listHum.Add(hum);
        CleanParams();
        ButtonsScript.ToStartMenu();
    }

    private void CleanParams()
    {
        SetEmplName.text = "";
        SetEmplLName.text = "";
        SetEmplPatronumic.text = "";
        SetEmplOrgName.text = "";
        SetEmplWorkPay.text = "";
        SetEmplWorkExp.text = "";
        SetEmplBirthday.text = "";
    }
}
