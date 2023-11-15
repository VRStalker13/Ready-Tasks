using UnityEngine;
using System;
using TMPro;

public class AddingStudentView : AddingHumanView
{
    [SerializeField]private TMP_InputField _studFacultyName;
    [SerializeField]private TMP_InputField _studCourse;
    [SerializeField]private TMP_InputField _studGroupNumber;
    
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

    protected void SaveInformation()
    {
        if (!string.IsNullOrEmpty(_humanName.text) && !string.IsNullOrEmpty(_humanLName.text) &&
            !string.IsNullOrEmpty(_humanPatronymic.text) && !string.IsNullOrEmpty(_studFacultyName.text) &&
            !string.IsNullOrEmpty(_studCourse.text) && !string.IsNullOrEmpty(_studGroupNumber.text) && 
            !string.IsNullOrEmpty(_humanBirthday.text))
        {
            Human hum = new Student(_humanName.text, _humanLName.text,
                _humanPatronymic.text, DateTime.Parse(_humanBirthday.text),
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

    protected override void CleanTextVariables()
    {
        base.CleanTextVariables();
        _studFacultyName.text = "";
        _studCourse.text = "";
        _studGroupNumber.text = "";
    }
}
