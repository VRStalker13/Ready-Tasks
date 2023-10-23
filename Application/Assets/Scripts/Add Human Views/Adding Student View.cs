using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Serialization;

public class AddingStudentView : AddingHumanView
{
    [SerializeField]private TMP_InputField _studFacultyName;
    [SerializeField]private TMP_InputField _studCourse;
    [SerializeField]private TMP_InputField _studGroupNumber;
    
    public void SaveInformation()
    {
        if (HumanName.text != "" && HumanLName.text != "" && HumanPatronymic.text != "" &&
            _studFacultyName.text != "" && _studCourse.text != "" &&
            _studGroupNumber.text != "" && HumanBirthday.text != "")
        {
            Human hum = new Student(HumanName.text, HumanLName.text,
                HumanPatronymic.text, DateTime.Parse(HumanBirthday.text),
                _studFacultyName.text, _studCourse.text,
                _studGroupNumber.text);
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
        _studFacultyName.text = "";
        _studCourse.text = "";
        _studGroupNumber.text = "";
    }
}
