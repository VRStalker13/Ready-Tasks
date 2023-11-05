using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListParamsForChangingWindow : View
{
    public static ListParamsForChangingWindow ListParamsForChange;
    
    [SerializeField] private TextMeshProUGUI _listParamsForChanging;// Список параметров для изменения
    [SerializeField] private TMP_InputField _input;// Номер выбранного параметра
    [SerializeField] private Button _saveButton;
    private int _maxValue;
    
    private void Awake() => ListParamsForChange = this;

    private void Start()
    {
        _saveButton.onClick.AddListener(SaveInformation);
    }
    
    public override void Initialize()
    {
        CleanTextVariables();
    }
    
    private void SaveInformation()
    {
        if (ApplicationData.AppData.ListHum.Count > 0)
        {
            _maxValue = ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Student ? 7: 
                ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Driver? 9:
                ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman] is Employer? 7: 0;
        }
        
        if (!string.IsNullOrEmpty(_input.text) && _maxValue != 0)
        {
            if (int.Parse(_input.text) <= _maxValue && int.Parse(_input.text) > 0)
            {
                ApplicationData.AppData.ChoosenNumberOfParam = int.Parse(_input.text);
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

    public void ShowListParams()
    {
        _listParamsForChanging.text =
            ApplicationData.AppData.ListHum[ApplicationData.AppData.ChoosenNumberOfHuman].ListChanges();
    }

    private void CleanTextVariables()
    {
        _listParamsForChanging.text = "";
        _input.text = "";
    }
}
