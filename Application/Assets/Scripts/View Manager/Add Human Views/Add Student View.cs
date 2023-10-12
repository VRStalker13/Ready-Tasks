using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class AddStudentView : View
{
    [SerializeField]private TMP_InputField _setStudName;
    [SerializeField]private TMP_InputField _setStudLName;
    [SerializeField]private TMP_InputField _setStudPatronymic;
    [SerializeField]private TMP_InputField _setStudFacultyName;
    [SerializeField]private TMP_InputField _setStudCourse;
    [SerializeField]private TMP_InputField _setStudGroupNumber;
    [SerializeField]private TMP_InputField _setStudBirthday;
    [SerializeField]private Button _save;

    private void Update()
    {
        ActivateSave();
    }

    private void ActivateSave()
    {
        if (_setStudName.text != "" && _setStudLName.text != "" &&
            _setStudPatronymic.text != "" && _setStudFacultyName.text != "" &&
            _setStudCourse.text != "" && _setStudGroupNumber.text != "" &&
            _setStudBirthday.text != "")
            _save.interactable = true;
        else
            _save.interactable = false;
    }
    
    public void SaveInformation()
    {
        Human hum = new Student(_setStudName.text, _setStudLName.text,
            _setStudPatronymic.text, DateTime.Parse(_setStudBirthday.text),
            _setStudFacultyName.text, _setStudCourse.text,
            _setStudGroupNumber.text);
        ViewManager.s_instance.ListHum.Add(hum);
        CleanTextVariables();
        ViewManager.s_instance.ToMainMenu();
    }

    public override void Initialize()
    {
        _save.onClick.AddListener(SaveInformation);
        _save.interactable = false;
    }
    
    private void CleanTextVariables()
    {
        _setStudName.text = "";
        _setStudLName.text = "";
        _setStudPatronymic.text = "";
        _setStudFacultyName.text = "";
        _setStudCourse.text = "";
        _setStudGroupNumber.text = "";
        _setStudBirthday.text = "";
    }
}
