using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class BirthdayFormat : MonoBehaviour
{
    private TMP_InputField _inputField;
    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onEndEdit.AddListener(OnInputEndEdit);
    }
    private void OnInputEndEdit(string str)
    {
        if (!DateTime.TryParseExact(str, "dd.MM.yyyy", null, DateTimeStyles.None, out _))
            _inputField.text = "";
    }

}
