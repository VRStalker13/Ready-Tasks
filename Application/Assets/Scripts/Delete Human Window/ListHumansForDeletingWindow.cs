using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ListHumansForDeletingWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _listHumansForDeleting;// Список людей для удаления
    [SerializeField] private TMP_InputField _input;// Номер выбранного человека
    [SerializeField] private Button _saveButton;
    private string _chosenNumber;

    private void Start()
    {
        _saveButton.onClick.AddListener(SaveInformation);
    }
    
    public override void Initialize()
    {
        CleanTextVariables();
    }

    public override void SetParams()
    {
        var count = ApplicationData.AppData.ListHum.Count;
        var text = "Human List:\n";
            
        for (var i = 0; i < count; i++)            
            text = $"{text}\n{i + 1}. {ApplicationData.AppData.ListHum[i].FirstName} " +
                   $"{ApplicationData.AppData.ListHum[i].LastName} " +
                   $"{ApplicationData.AppData.ListHum[i].Patronymic}";

        _listHumansForDeleting.text = text;
    }

    private void SaveInformation()
    {
        if (!string.IsNullOrEmpty(_input.text))
        {
            if (int.Parse(_input.text) <= ApplicationData.AppData.ListHum.Count && int.Parse(_input.text) > 0)
            {
                _chosenNumber = new string(_input.text);
                ApplicationData.AppData.ListHum.RemoveAt(int.Parse(_chosenNumber) - 1);
                CleanTextVariables();
                ViewManager.Instance.ToMainMenu();
            }
            else
            {
                ViewManager.Instance.ErrorWindow.SetActive(true);
            }
        }
    }
    
    private void CleanTextVariables()
    {
        _listHumansForDeleting.text = "";
        _input.text = "";
    }
}
