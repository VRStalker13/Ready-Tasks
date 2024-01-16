using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecordsMenuWindow : ViewMethods
{
    /// <summary>
    /// Список экранных обЪектов в которых отображаюся рекорды
    /// </summary>
    [SerializeField] public List<RecordBlock> _listRecords;
    [SerializeField] private Button _toMainMenuButton;
    
    private void Start()
    {
        SetParams();
        SetButtonActivity();
        AddOnPointerEnter(new []{_toMainMenuButton},EventTriggerType.PointerEnter,(data) => GameMusic.Music.PlayButtonsMusic(true));
    }

    private void SetButtonActivity()
    {
        _toMainMenuButton.onClick.AddListener(()=>ViewManager.Instance.Show<MainMenu>());
        AddOnPointerEnter(new []{_toMainMenuButton},EventTriggerType.PointerEnter,(data) => GameMusic.Music.PlayButtonsMusic(true));
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
