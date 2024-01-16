using System.Collections.Generic;
using UnityEngine;

public class ApplicationData
{
    public static ApplicationData AppData = new ApplicationData();

    public bool _isOnMusicEffects = true;
    public bool _isOnGameSound = true;
    public bool IsPlayMenuMusic;
    public bool IsPlayGameMusic;

    public float GameScore;
    public float GameTime;
    public bool GameProcessIsOn;
    
    public GameResultData[] GameRes = new GameResultData[11];
    
    public readonly int _maxRoadCount = 20;
    public readonly int _maxStotesCount = 19;
    public readonly float _startSpeed = 5f;
    public float _speed;
    public float Acceleration = 1;
    public bool _trigger = true;
    
    public void CreateStartRecordsList()
    {
        for (var i = 0; i < AppData.GameRes.Length; i++)
            AppData.GameRes[i] = new GameResultData();
    }
}

