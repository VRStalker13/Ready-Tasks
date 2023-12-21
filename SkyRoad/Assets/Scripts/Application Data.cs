using System.Collections.Generic;
using UnityEngine;

public class ApplicationData
{
    public static ApplicationData AppData = new ApplicationData();

    public bool _isOnMusicEffects = true;
    public bool _isOnGameSound = true;
    public bool IsPlayMenuMusic;
    public bool IsPlayGameMusic;

    public float GameScore = 0f;
    public float GameTime = 0f;
    public bool GameProcessIsOn = false;

    public List<GameObject> _roads = new List<GameObject>();
    public List<GameObject> _stones = new List<GameObject>();
    
    public GameResult[] GameRes = new GameResult[11];
    
    public readonly int _maxRoadCount = 20;
    public readonly int _maxStotesCount = 19;
    public readonly float _startSpeed = 5f;
    public float _speed = 0f;
    public float Acceleration = 1;
    public bool _trigger = true;
}
