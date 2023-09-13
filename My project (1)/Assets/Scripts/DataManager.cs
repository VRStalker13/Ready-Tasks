using System;
using System.Globalization;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    private TMP_InputField inputField;
    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(OnInputEndEdit);
    }
    private void OnInputEndEdit(string str)
    {
        DateTime birthday;
        
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out birthday))
            inputField.text = "";
    }
}
