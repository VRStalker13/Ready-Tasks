using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsMenuWindow : ViewMethods
{
    /// <summary>
    /// Список экранных обЪектов в которых отображаюся рекорды
    /// </summary>
    [SerializeField] public List<RecordBlock> _listRecords;
    [SerializeField] private Button _toMainMenuButton;

    private void Awake()
    {
        CreateStartRecordsList();
    }
    
    void Start()
    {
        SetParams();
        SetButtonActivity();
        OnPointerEnterButtons(new Button[]{_toMainMenuButton});
    }

    private void SetButtonActivity()
    {
        _toMainMenuButton.onClick.AddListener(()=>ViewManager.Instance.Show<MainMenu>());
        OnPointerEnterButtons(new Button[]{_toMainMenuButton});
    }

    private void CreateStartRecordsList()
    {
        for (int i = 0; i < ApplicationData.AppData.GameRes.Length; i++)
            ApplicationData.AppData.GameRes[i] = new GameResult();
    }

    public override void SetParams()
    {
        var gameRes = ApplicationData.AppData.GameRes;

        for (var i = 0; i < _listRecords.Count; i++)
        {
            _listRecords[i].Date.text = gameRes[i].Date == DateTime.MinValue?"-":gameRes[i].Date.ToString("d");
            _listRecords[i].Score.text = gameRes[i].ScoreValue == 0?"-":gameRes[i].ScoreValue.ToString();
            _listRecords[i].Time.text = gameRes[i].Time == 0?"-":gameRes[i].Time.ToString();
        }
    }
}
