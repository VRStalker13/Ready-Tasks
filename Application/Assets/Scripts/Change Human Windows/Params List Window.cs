using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListParamsForChangingWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private Button _save;
    private int _maxValue;

    public void SaveInformation()
    {
        if (ViewManager._instance.ListHum.Count > 0)
        {
            _maxValue = ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Student ? 7: 
                ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Driver? 9:
                ViewManager._instance.ListHum[ViewManager._instance.ChoosenNumberOfHuman] is Employer? 7: 0;
        }
        
        if (_input.text != "" && _maxValue!=0)
        {
            if (int.Parse(_input.text) <= _maxValue && int.Parse(_input.text) > 0)
            {
                ViewManager._instance.ChoosenNumberOfParam = int.Parse(_input.text);
                ViewManager._instance.ToNextWindow();
                CleanTextVariables();
                ViewManager._instance.ToNextWindowButton.gameObject.SetActive(true);
            }
            else
            {
                ViewManager._instance.ErrorWindow.SetActive(true);
            }
            
        }
    }

    public override void Initialize()
    {
        _save.onClick.AddListener(SaveInformation);
        _input.text = "";
    }
    
    private void CleanTextVariables()
    {
        _input.text = "";
    }
}
