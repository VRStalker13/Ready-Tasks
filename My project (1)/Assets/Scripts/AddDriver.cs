using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddDriver : MonoBehaviour
{
    [SerializeField]private TMP_InputField SetDriverName;
    [SerializeField]private TMP_InputField SetDriverLName;
    [SerializeField]private TMP_InputField SetDriverPatronumic;
    [SerializeField]private TMP_InputField SetDriverOrgName;
    [SerializeField]private TMP_InputField SetDriverWorkPay;
    [SerializeField]private TMP_InputField SetDriverWorkExp;
    [SerializeField]private TMP_InputField SetDriverBrandCar;
    [SerializeField]private TMP_InputField SetDriverModelCar;
    [SerializeField]private TMP_InputField SetDriverBirthday;
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
        if (SetDriverName.text != "" && SetDriverLName.text != "" &&
            SetDriverPatronumic.text != "" && SetDriverOrgName.text != "" &&
            SetDriverWorkPay.text != "" && SetDriverWorkExp.text != "" &&
            SetDriverBrandCar.text != ""&& SetDriverModelCar.text != ""&& 
            SetDriverBirthday.text != "")
        {
            _save.interactable = true;
        }
        else
        {
            _save.interactable = false;
        }
    }
    
    public void SaveInformation()
    {
        Human hum = new Driver(SetDriverName.text,SetDriverLName.text,SetDriverPatronumic.text,
            DateTime.Parse(SetDriverBirthday.text),SetDriverOrgName.text,SetDriverWorkPay.text,
            SetDriverWorkExp.text,SetDriverBrandCar.text,SetDriverModelCar.text);
        MemoryScript.listHum.Add(hum);
        CleanParams();
        ButtonsScript.ToStartMenu();
    }
    
    private void CleanParams()
    {
        SetDriverName.text = "";
        SetDriverLName.text = "";
        SetDriverPatronumic.text = "";
        SetDriverOrgName.text = "";
        SetDriverWorkPay.text = "";
        SetDriverWorkExp.text = "";
        SetDriverBrandCar.text = "";
        SetDriverModelCar.text = "";
        SetDriverBirthday.text = "";
    }
    

}
