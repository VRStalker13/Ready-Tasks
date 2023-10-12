using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ChangeProccesWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _save;

    private void Update()
    {
        if (ViewManager.s_instance.ListHum.Count != 0)
        {
            ParametersName();
        }
        
        if (_input.text.Length > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    private void ParametersName()
    {
        switch (ViewManager.s_instance._choosenNumberOfParam)
        {
            case 1:
                _text.text = "New name is: ";
                return;
            case 2:
                _text.text = "New Lastname is: ";
                return;
            case 3:
                _text.text = "New Patronymic is: ";
                return;
            case 4:
                _text.text = "New Birthday is: ";
                return;
        }

        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Student)
        {
            switch (ViewManager.s_instance._choosenNumberOfParam)
            {
                case 5:
                    _text.text = "New Faculty is: ";;
                    return;
                case 6:
                    _text.text = "New Course is: ";
                    return;
                case 7:
                    _text.text = "New GroupNum is: ";
                    return;  
            }
        }

        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Employer ||
            ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Driver )
        {
            switch (ViewManager.s_instance._choosenNumberOfParam)
            {
                case 5:
                    _text.text = "New Organization is: ";
                    return;
                case 6:
                    _text.text = "New WorkPay is: ";
                    return;
                case 7:
                    _text.text = "New WorkExp is: ";
                    return;
            }
        }

        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Driver )
        {
            switch (ViewManager.s_instance._choosenNumberOfParam)
            {
                case 8:
                    _text.text = "New CarBrand is: ";
                    return;
                case 9:
                    _text.text = "New CarModel is: ";
                    return; 
            }
        }
    }
    
    public void Change()
    {
        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Student stud)
            ChangeStudent(stud);

        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Employer empl)
            ChangeEmployer(empl);

        if (ViewManager.s_instance.ListHum[ViewManager.s_instance._choosenNumberOfHuman] is Driver driver)
            ChangeDriver(driver);
        
        CleanTextVariables();
        ViewManager.s_instance.Show<MainMenuWindow>();
    }

    private void ChangeDriver(Driver driver)
    {
        switch (ViewManager.s_instance._choosenNumberOfParam)
        {
            case 1:
                driver.FirstName = _input.text;
                return;
            case 2:
                driver.LastName = _input.text;
                return;
            case 3:
                driver.Patronymic = _input.text;
                return;
            case 4:
                driver.Birthday = DateTime.Parse(_input.text);
                return;
            case 5:
                driver.Organization = _input.text;
                return;
            case 6:
                driver.WorkPay = _input.text;
                return;
            case 7:
                driver.WorkExp = _input.text;
                return;
            case 8:
                driver.CarBrand = _input.text;
                return;
            case 9:
                driver.CarModel = _input.text;
                return;
        }
    }
    
    private void ChangeEmployer(Employer empl)
    {
        switch (ViewManager.s_instance._choosenNumberOfParam)
        {
            case 1:
                empl.FirstName =_input.text;
                return;
            case 2:
                empl.FirstName = _input.text;
                return;
            case 3:
                empl.Patronymic = _input.text;
                return;
            case 4:
                empl.Birthday = DateTime.Parse(_input.text);
                return;
            case 5:
                empl.Organization = _input.text;
                return;
            case 6:
                empl.WorkPay = _input.text;
                return;
            case 7:
                empl.WorkExp = _input.text;
                return;
        }
    }

    private void ChangeStudent(Student stud)
    {
        switch (ViewManager.s_instance._choosenNumberOfParam)
        {
            case 1:
                stud.FirstName = _input.text;
                return;
            case 2:
                stud.LastName = _input.text;
                return;
            case 3:
                stud.Patronymic = _input.text;
                return;
            case 4:
                stud.Birthday = DateTime.Parse(_input.text);
                return;
            case 5:
                stud.Faculty = _input.text;
                return;
            case 6:
                stud.Course = _input.text;
                return;
            case 7:
                stud.GroupNum = _input.text;
                return;
        }
    }
    
    private void CleanTextVariables()
    {
        _input.text = "";
        _text.text = "";
    }

    public override void Initialize()
    {
        _save.onClick.AddListener(Change);
    }
}
