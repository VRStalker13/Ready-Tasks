using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ListHumansForDeletingWindow : View
{
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private Button _save;
    private string _chosenNumber;

    public void SaveInformation()
    {
        if (_input.text != "")
        {
            if (int.Parse(_input.text) <= ViewManager._instance.ListHum.Count && int.Parse(_input.text) > 0)
            {
                _chosenNumber = new string(_input.text);
                ViewManager._instance.ListHum.RemoveAt(int.Parse(_chosenNumber) - 1);
                CleanTextVariables();
                ViewManager._instance.ToMainMenu();
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
    }

    private void CleanTextVariables()
    {
        _input.text = "";
    }
}
