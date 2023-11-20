using UnityEngine;
using System;
using TMPro;

public class AddStudentWindow : AddHumanWindow
{
    [SerializeField]private TMP_InputField _studFacultyName;
    [SerializeField]private TMP_InputField _studCourse;
    [SerializeField]private TMP_InputField _studGroupNumber;
    
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

    protected void SaveInformation()
    {
        if (!CheckNullOrEmpty())
        {
            Human hum = new Student(HumanName.text, HumanLName.text,
                HumanPatronymic.text, DateTime.Parse(HumanBirthday.text),
                _studFacultyName.text, _studCourse.text,
                _studGroupNumber.text);
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
        if (!base.CheckNullOrEmpty() && !string.IsNullOrEmpty(_studFacultyName.text) &&
            !string.IsNullOrEmpty(_studCourse.text) && !string.IsNullOrEmpty(_studGroupNumber.text))
            return false;
        else
            return true;
    }

    protected override void CleanTextVariables()
    {
        base.CleanTextVariables();
        _studFacultyName.text = "";
        _studCourse.text = "";
        _studGroupNumber.text = "";
    }
}
