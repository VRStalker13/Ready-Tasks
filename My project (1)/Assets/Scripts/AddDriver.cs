using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddDriver : MonoBehaviour
{
    [SerializeField]private TMP_InputField _setDriverName;
    [SerializeField]private TMP_InputField _setDriverLName;
    [SerializeField]private TMP_InputField _setDriverPatronymic;
    [SerializeField]private TMP_InputField _setDriverOrgName;
    [SerializeField]private TMP_InputField _setDriverWorkPay;
    [SerializeField]private TMP_InputField _setDriverWorkExp;
    [SerializeField]private TMP_InputField _setDriverBrandCar;
    [SerializeField]private TMP_InputField _setDriverModelCar;
    [SerializeField]private TMP_InputField _setDriverBirthday;
    [SerializeField]private Button _save;
    
    private void Start()
    {
        _save.interactable = false;
    }

    private void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (_setDriverName.text != "" && _setDriverLName.text != "" &&
            _setDriverPatronymic.text != "" && _setDriverOrgName.text != "" &&
            _setDriverWorkPay.text != "" && _setDriverWorkExp.text != "" &&
            _setDriverBrandCar.text != ""&& _setDriverModelCar.text != ""&& 
            _setDriverBirthday.text != "")
            _save.interactable = true;
        else
            _save.interactable = false;
    }
    
    public void SaveInformation()
    {
        Human hum = new Driver(_setDriverName.text,_setDriverLName.text,_setDriverPatronymic.text,
            DateTime.Parse(_setDriverBirthday.text),_setDriverOrgName.text,_setDriverWorkPay.text,
            _setDriverWorkExp.text,_setDriverBrandCar.text,_setDriverModelCar.text);
        MemoryScript.ListHum.Add(hum);
        ButtonsScript.ToStartMenu();
    }
}
