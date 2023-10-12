using System;
using System.Globalization;
using UnityEngine;
using TMPro;

public class ChangeParamFormat : MonoBehaviour
{
    private TMP_InputField _inputField;
    
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();

        if (ViewManager.s_instance._choosenNumberOfParam == 4)
        {
            _inputField.contentType = TMP_InputField.ContentType.Standard;
            _inputField.onEndEdit.AddListener(OnInputEndEdit);
        }
        else
            _inputField.onValueChanged.AddListener(OnValueChange);
    }
    
    private void OnInputEndEdit(string str)
    {
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            _inputField.text = "";
    }
    
    private void OnValueChange(string str)
    {
        if (ViewManager.s_instance._choosenNumberOfParam < 4 || ViewManager.s_instance._choosenNumberOfParam == 5 ||
            ViewManager.s_instance._choosenNumberOfParam >= 8 )
            _inputField.contentType = TMP_InputField.ContentType.Name;

        if (ViewManager.s_instance._choosenNumberOfParam == 6 || ViewManager.s_instance._choosenNumberOfParam == 7 )
            _inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
    }
}
