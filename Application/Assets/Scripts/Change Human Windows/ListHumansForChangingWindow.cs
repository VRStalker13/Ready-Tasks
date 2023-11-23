using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ListHumansForChangingWindow : ViewMethods
{
    [SerializeField] private TextMeshProUGUI _listHumansForChange;// Список людей для изменения
    [SerializeField] private TMP_InputField _input; // Номер выбранного человека
    [SerializeField] private Button _saveButton;

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

        _listHumansForChange.text = text;
    }

    private void SaveInformation()
    {
        if (!string.IsNullOrEmpty(_input.text))
        {
            if (int.Parse(_input.text) <= ApplicationData.AppData.ListHum.Count && int.Parse(_input.text) > 0)
            {
                ApplicationData.AppData.ChosenNumberOfHuman = int.Parse(_input.text) - 1;
                ViewManager.Instance.ToNextWindow();
                CleanTextVariables();
                ViewManager.Instance.ToNextWindowButton.gameObject.SetActive(true);
            }
            else
            {
                ViewManager.Instance.ErrorWindow.SetActive(true);
            }
        }
    }

    private void CleanTextVariables()
    {
        _input.text = "";
        _listHumansForChange.text = "";
    }
}
