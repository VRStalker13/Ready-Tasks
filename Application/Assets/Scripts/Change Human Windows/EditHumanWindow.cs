using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditHumanWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _nameChangingParametr;// Название изменяемого параметра
    [SerializeField] private TMP_InputField _newParameterValue;// Новое значение параметра при изменении
    [SerializeField] private Button _saveButton;

    private int _chosenNumberOfParam;
    private Human _human;
    
    private void Start()
    {
        _saveButton.onClick.AddListener(Change);
    }
    
    public override void Initialize()
    {
        CleanTextVariables();
    }

    public override void SetParams()
    {
        _chosenNumberOfParam = ApplicationData.AppData.ChosenNumberOfParam;
        _human = ApplicationData.AppData.ListHum[ApplicationData.AppData.ChosenNumberOfHuman];
        SetNewParameterFormat();

        switch (_chosenNumberOfParam)
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

        if (_human is Student)
        {
            switch (_chosenNumberOfParam)
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

        if (_human is Employer || _human is Driver )
        {
            switch (_chosenNumberOfParam)
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

        if (_human is Driver )
        {
            switch (_chosenNumberOfParam)
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

    private void Change()
    {
        if (_newParameterValue.text.Length > 0)
        {
            if (_human is Student stud)
                ChangeStudent(stud);
    
            if (_human is Employer empl)
                ChangeEmployer(empl);
    
            if (_human is Driver driver)
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
        
        switch (_chosenNumberOfParam)
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
        
        switch (_chosenNumberOfParam)
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
        switch (_chosenNumberOfParam)
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
        
        switch (_chosenNumberOfParam)
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

    private void SetNewParameterFormat()
    {
        _newParameterValue.onEndEdit.RemoveAllListeners();
        _newParameterValue.onValueChanged.RemoveAllListeners();
        
        // 4-ый параметр это дата рождения
        if (_chosenNumberOfParam == 4)
            _newParameterValue.onEndEdit.AddListener(OnInputEndEdit);
        else
            _newParameterValue.onValueChanged.AddListener(OnValueChange);
    }
    
    // Метод задающий формат для ячейки в слечае если меняем дату рождения
    private void OnInputEndEdit(string str)
    {
        _newParameterValue.contentType = TMP_InputField.ContentType.Standard;
        
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            _newParameterValue.text = "";
    }
    
    // Метод задающий формат для ячейки если меняем не дату родения а другие поля человека
    private void OnValueChange(string str)
    {
        // Для текстовых полей человека устанавливаем тип чтобы можно было вводить лишь буквы
        if (_chosenNumberOfParam < 4 || _chosenNumberOfParam == 5 || _chosenNumberOfParam >= 8 )
            _newParameterValue.contentType = TMP_InputField.ContentType.Name;

        // Для численных полей человека устанавливаем чтобы можно было вводить лишь числа 
        if (_chosenNumberOfParam == 6 || _chosenNumberOfParam == 7 )
            _newParameterValue.contentType = TMP_InputField.ContentType.IntegerNumber;
    }
}
