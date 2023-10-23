using UnityEngine;
using UnityEngine.UI;
using System;

public class ProcessChangingHumanWindow : View
{
    [SerializeField] private Button _save;

    public void Change()
    {
        if (ViewManager._instance.NewParameterValue.text.Length > 0)
        {
            if (ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Student stud)
                ChangeStudent(stud);
    
            if (ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Employer empl)
                ChangeEmployer(empl);
    
            if (ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Driver driver)
                ChangeDriver(driver);
            
            CleanTextVariables();
            ViewManager._instance.Show<MainMenuWindow>();
        }
        else
        {
            ViewManager._instance.ErrorWindow.SetActive(true);
        }

    }

    private void ChangeDriver(Driver driver)
    {
        switch (ViewManager._instance.ChoosenNumberOfParam)
        {
            case 1:
                driver.FirstName = ViewManager._instance.NewParameterValue.text;
                return;
            case 2:
                driver.LastName = ViewManager._instance.NewParameterValue.text;
                return;
            case 3:
                driver.Patronymic = ViewManager._instance.NewParameterValue.text;
                return;
            case 4:
                driver.Birthday = DateTime.Parse(ViewManager._instance.NewParameterValue.text);
                return;
            case 5:
                driver.Organization = ViewManager._instance.NewParameterValue.text;
                return;
            case 6:
                driver.WorkPay = ViewManager._instance.NewParameterValue.text;
                return;
            case 7:
                driver.WorkExp = ViewManager._instance.NewParameterValue.text;
                return;
            case 8:
                driver.CarBrand = ViewManager._instance.NewParameterValue.text;
                return;
            case 9:
                driver.CarModel = ViewManager._instance.NewParameterValue.text;
                return;
        }
    }
    
    private void ChangeEmployer(Employer empl)
    {
        switch (ViewManager._instance.ChoosenNumberOfParam)
        {
            case 1:
                empl.FirstName =ViewManager._instance.NewParameterValue.text;
                return;
            case 2:
                empl.FirstName = ViewManager._instance.NewParameterValue.text;
                return;
            case 3:
                empl.Patronymic = ViewManager._instance.NewParameterValue.text;
                return;
            case 4:
                empl.Birthday = DateTime.Parse(ViewManager._instance.NewParameterValue.text);
                return;
            case 5:
                empl.Organization = ViewManager._instance.NewParameterValue.text;
                return;
            case 6:
                empl.WorkPay = ViewManager._instance.NewParameterValue.text;
                return;
            case 7:
                empl.WorkExp = ViewManager._instance.NewParameterValue.text;
                return;
        }
    }

    private void ChangeStudent(Student stud)
    {
        switch (ViewManager._instance.ChoosenNumberOfParam)
        {
            case 1:
                stud.FirstName = ViewManager._instance.NewParameterValue.text;
                return;
            case 2:
                stud.LastName = ViewManager._instance.NewParameterValue.text;
                return;
            case 3:
                stud.Patronymic = ViewManager._instance.NewParameterValue.text;
                return;
            case 4:
                stud.Birthday = DateTime.Parse(ViewManager._instance.NewParameterValue.text);
                return;
            case 5:
                stud.Faculty = ViewManager._instance.NewParameterValue.text;
                return;
            case 6:
                stud.Course = ViewManager._instance.NewParameterValue.text;
                return;
            case 7:
                stud.GroupNum = ViewManager._instance.NewParameterValue.text;
                return;
        }
    }
    
    private void CleanTextVariables()
    {
        ViewManager._instance.NewParameterValue.text = "";
    }

    public override void Initialize()
    {
        _save.onClick.AddListener(Change);
    }
}
