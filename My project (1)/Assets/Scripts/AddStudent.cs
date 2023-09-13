using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddStudent : MonoBehaviour
{
    [SerializeField]private TMP_InputField SetStudName;
    [SerializeField]private TMP_InputField SetStudLName;
    [SerializeField]private TMP_InputField SetStudPatronumic;
    [SerializeField]private TMP_InputField SetStudFacultyName;
    [SerializeField]private TMP_InputField SetStudCourse;
    [SerializeField]private TMP_InputField SetStudGroupNumber;
    [SerializeField]private TMP_InputField SetStudBirthday;
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
        if (SetStudName.text != "" && SetStudLName.text != "" &&
            SetStudPatronumic.text != "" && SetStudFacultyName.text != "" &&
            SetStudCourse.text != "" && SetStudGroupNumber.text != "" &&
            SetStudBirthday.text != "")
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
        Human hum = new Student(SetStudName.text, SetStudLName.text,
            SetStudPatronumic.text, DateTime.Parse(SetStudBirthday.text),
            SetStudFacultyName.text, SetStudCourse.text,
            SetStudGroupNumber.text);
        MemoryScript.listHum.Add(hum);
        CleanParams();
        ButtonsScript.ToStartMenu();
    }
    
    private void CleanParams()
    {
        SetStudName.text = "";
        SetStudLName.text = "";
        SetStudPatronumic.text = "";
        SetStudFacultyName.text = "";
        SetStudCourse.text = "";
        SetStudGroupNumber.text = "";
        SetStudBirthday.text = "";
    }
}
