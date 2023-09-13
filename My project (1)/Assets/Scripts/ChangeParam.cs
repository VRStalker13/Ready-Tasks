using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParam : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button _save;

    private void Start()
    {
        _save.interactable = false;
        ParametrsName();
    }
    
    private void Update()
    {
        if (_input.text.Length > 0)
            _save.interactable = true;
        else
            _save.interactable = false;
    }

    private void ParametrsName()
    {
        switch (int.Parse(MemoryScript.changeParamNumer))
        {
            case 1:
                text.text = "New name is: ";
                return;
            case 2:
                text.text = "New Lastname is: ";
                return;
            case 3:
                text.text = "New Patronymic is: ";
                return;
            case 4:
                text.text = "New Birthday is: ";
                return;
        }

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Student)
        {
            switch (int.Parse(MemoryScript.changeParamNumer))
            {
                case 5:
                    text.text = "New Faculty is: ";;
                    return;
                case 6:
                    text.text = "New Course is: ";
                    return;
                case 7:
                    text.text = "New GroupNum is: ";
                    return;  
            }
        }

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Employee ||
            MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Driver )
        {
            switch (int.Parse(MemoryScript.changeParamNumer))
            {
                case 5:
                    text.text = "New Organization is: ";
                    return;
                case 6:
                    text.text = "New WorkPay is: ";
                    return;
                case 7:
                    text.text = "New WorkExp is: ";
                    return;
            }
        }

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Driver )
        {
            switch (int.Parse(MemoryScript.changeParamNumer))
            {
                case 8:
                    text.text = "New CarBrand is: ";
                    return;
                case 9:
                    text.text = "New CarModel is: ";
                    return; 
            }
        }
    }
    
    public void Change()
    {
        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Student stud)
            ChangeStudent(stud, int.Parse(MemoryScript.showHumanNumber));

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Employee empl)
            ChangeEmployee(empl, int.Parse(MemoryScript.showHumanNumber));

        if (MemoryScript.listHum[int.Parse(MemoryScript.showHumanNumber) - 1] is Driver driver)
            ChangeDriver(driver, int.Parse(MemoryScript.showHumanNumber));
        
        ButtonsScript.ToStartMenu();
    }

    private void ChangeDriver(Driver driver, int humNum)
    {
        switch (int.Parse(MemoryScript.changeParamNumer))
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
            default:
                break;
        }
    }
    
    private void ChangeEmployee(Employee empl, int humNum)
    {
        switch (int.Parse(MemoryScript.changeParamNumer))
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
            default:
                break;
        }
    }

    private void ChangeStudent(Student stud, int humNum)
    {
        switch (int.Parse(MemoryScript.changeParamNumer))
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
            default:
                break;
        }
    }
}

