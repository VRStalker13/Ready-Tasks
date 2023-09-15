using System;
using System.Globalization;
using UnityEngine;
using TMPro;

public class ChangeParamManager : MonoBehaviour
{
    private TMP_InputField _inputField;
    
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();

        if (int.Parse(MemoryScript.ChangeParamNumber) == 4)
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
        if (int.Parse(MemoryScript.ChangeParamNumber) < 4 || int.Parse(MemoryScript.ChangeParamNumber) == 5 ||
            int.Parse(MemoryScript.ChangeParamNumber) >= 8 )
            _inputField.contentType = TMP_InputField.ContentType.Name;

        if (int.Parse(MemoryScript.ChangeParamNumber) == 6 || int.Parse(MemoryScript.ChangeParamNumber) == 7 )
            _inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
    }
}
