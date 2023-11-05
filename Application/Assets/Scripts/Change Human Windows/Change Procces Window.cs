using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProcessChangingHumanWindow : View
{
    public static ProcessChangingHumanWindow ProcessChanging;
    
    [SerializeField] private TextMeshProUGUI _nameChangingParametr;// Название изменяемого параметра
    [SerializeField] private TMP_InputField _newParameterValue;// Новое значение параметра при изменении
    [SerializeField] private Button _saveButton;

    private void Awake() => ProcessChanging = this;
    
    private void Start()
    {
        _saveButton.onClick.AddListener(Change);
    }
    
    public override void Initialize()
    {
        CleanTextVariables();
    }

    private void Change()
    {
        if (_newParameterValue.text.Length > 0)
        {
            if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Student stud)
                ChangeStudent(stud);
    
            if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Employer empl)
                ChangeEmployer(empl);
    
            if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Driver driver)
                ChangeDriver(driver);
            
            CleanTextVariables();
            ViewManager.Instance.Show<MainMenuWindow>();
        }
        else
        {
            ViewManager.Instance.ErrorWindow.SetActive(true);
        }
    }

    private void ChangeDriver(Driver driver)
    {
        ChangeHuman(driver);
        ChangeEmployer(driver);
        
        switch (ApplicationData.AppData.ChoosenNumberOfParam)
        {
            case 8:
                driver.CarBrand = _newParameterValue.text;
                return;
            case 9:
                driver.CarModel = _newParameterValue.text;
                return;
        }
    }
    
    private void ChangeEmployer(Employer empl)
    {
        ChangeHuman(empl);
        
        switch (ApplicationData.AppData.ChoosenNumberOfParam)
        {
            case 5:
                empl.Organization = _newParameterValue.text;
                return;
            case 6:
                empl.WorkPay = _newParameterValue.text;
                return;
            case 7:
                empl.WorkExp = _newParameterValue.text;
                return;
        }
    }
    
    private void ChangeHuman(Human hum)
    {
        switch (ApplicationData.AppData.ChoosenNumberOfParam)
        {
            case 1:
                hum.FirstName = _newParameterValue.text;
                return;
            case 2:
                hum.FirstName = _newParameterValue.text;
                return;
            case 3:
                hum.Patronymic = _newParameterValue.text;
                return;
            case 4:
                hum.Birthday = DateTime.Parse(_newParameterValue.text);
                return;
        }
    }

    private void ChangeStudent(Student stud)
    {
        ChangeHuman(stud);
        
        switch (ApplicationData.AppData.ChoosenNumberOfParam)
        {
            case 5:
                stud.Faculty = _newParameterValue.text;
                return;
            case 6:
                stud.Course = _newParameterValue.text;
                return;
            case 7:
                stud.GroupNum = _newParameterValue.text;
                return;
        }
    }
    
    private void CleanTextVariables()
    {
        _nameChangingParametr.text = "";
        _newParameterValue.text = "";
    }
    
    public void NewParameterName()
    {
        switch (ApplicationData.AppData.ChoosenNumberOfParam)
        {
            case 1:
                _nameChangingParametr.text = "New name is: ";
                return;
            case 2:
                _nameChangingParametr.text = "New Lastname is: ";
                return;
            case 3:
                _nameChangingParametr.text = "New Patronymic is: ";
                return;
            case 4:
                _nameChangingParametr.text = "New Birthday is: ";
                return;
        }

        if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Student)
        {
            switch (ApplicationData.AppData.ChoosenNumberOfParam)
            {
                case 5:
                    _nameChangingParametr.text = "New Faculty is: ";;
                    return;
                case 6:
                    _nameChangingParametr.text = "New Course is: ";
                    return;
                case 7:
                   _nameChangingParametr.text = "New GroupNum is: ";
                    return;  
            }
        }

        if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Employer ||
            ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Driver )
        {
            switch (ApplicationData.AppData.ChoosenNumberOfParam)
            {
                case 5:
                    _nameChangingParametr.text = "New Organization is: ";
                    return;
                case 6:
                    _nameChangingParametr.text = "New WorkPay is: ";
                    return;
                case 7:
                    _nameChangingParametr.text = "New WorkExp is: ";
                    return;
            }
        }

        if (ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Driver )
        {
            switch (ApplicationData.AppData.ChoosenNumberOfParam)
            {
                case 8:
                    _nameChangingParametr.text = "New CarBrand is: ";
                    return;
                case 9:
                    _nameChangingParametr.text = "New CarModel is: ";
                    return; 
            }
        }
    }

    public void NewParameterFormat()
    {
        _newParameterValue.onEndEdit.RemoveAllListeners();
        _newParameterValue.onValueChanged.RemoveAllListeners();
        
        if (ApplicationData.AppData.ChoosenNumberOfParam == 4)
            _newParameterValue.onEndEdit.AddListener(OnInputEndEdit);
        else
            _newParameterValue.onValueChanged.AddListener(OnValueChange);
    }
    
    private void OnInputEndEdit(string str)
    {
        _newParameterValue.contentType = TMP_InputField.ContentType.Standard;
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            _newParameterValue.text = "";
    }
    
    private void OnValueChange(string str)
    {
        if (ApplicationData.AppData.ChoosenNumberOfParam < 4 || ApplicationData.AppData.ChoosenNumberOfParam == 5 ||
            ApplicationData.AppData.ChoosenNumberOfParam >= 8 )
            _newParameterValue.contentType = TMP_InputField.ContentType.Name;

        if (ApplicationData.AppData.ChoosenNumberOfParam == 6 || ApplicationData.AppData.ChoosenNumberOfParam == 7 )
            _newParameterValue.contentType = TMP_InputField.ContentType.IntegerNumber;
    }

}
