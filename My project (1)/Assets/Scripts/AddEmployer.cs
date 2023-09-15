using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddEmployer : MonoBehaviour
{
    [SerializeField]private TMP_InputField _setEmplName;
    [SerializeField]private TMP_InputField _setEmplLName;
    [SerializeField]private TMP_InputField _setEmplPatronymic;
    [SerializeField]private TMP_InputField _setEmplOrgName;
    [SerializeField]private TMP_InputField _setEmplWorkPay;
    [SerializeField]private TMP_InputField _setEmplWorkExp;
    [SerializeField]private TMP_InputField _setEmplBirthday;
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
        if (_setEmplName.text != "" && _setEmplLName.text != "" &&
            _setEmplPatronymic.text != "" && _setEmplOrgName.text != "" &&
            _setEmplWorkPay.text != "" && _setEmplWorkExp.text != "" &&
            _setEmplBirthday.text != "")
            _save.interactable = true;
        else
            _save.interactable = false;
    }
    
    public void SaveInformation()
    {
        Human hum = new Employer(_setEmplName.text, _setEmplLName.text, _setEmplPatronymic.text,
            DateTime.Parse(_setEmplBirthday.text), _setEmplOrgName.text, _setEmplWorkPay.text, _setEmplWorkExp.text);
        MemoryScript.ListHum.Add(hum);
        ButtonsScript.ToStartMenu();
    }
}
