using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ChangeParamManager : MonoBehaviour
{
    private TMP_InputField inputField;
    
    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();

        if (int.Parse(MemoryScript.changeParamNumer) == 4)
        {
            inputField.contentType = TMP_InputField.ContentType.Standard;
            inputField.onEndEdit.AddListener(OnInputEndEdit);
        }
        else
            inputField.onValueChanged.AddListener(OnValueChange);
    }
    
    private void OnInputEndEdit(string str)
    {
        DateTime birthday;
        
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out birthday))
            inputField.text = "";
    }
    
    private void OnValueChange(string str)
    {
        if (int.Parse(MemoryScript.changeParamNumer) < 4 || int.Parse(MemoryScript.changeParamNumer) == 5 ||
            int.Parse(MemoryScript.changeParamNumer) >= 8 )
            inputField.contentType = TMP_InputField.ContentType.Name;

        if (int.Parse(MemoryScript.changeParamNumer) == 6 || int.Parse(MemoryScript.changeParamNumer) == 7 )
            inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
    }
}
