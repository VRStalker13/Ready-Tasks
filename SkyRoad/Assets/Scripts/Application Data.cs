using UnityEngine;

public class ApplicationData
{
    public static ApplicationData AppData = new ApplicationData();

    public bool IsOnMusicEffects = true;
    public bool IsOnGameSound = true;
    public bool IsPlayMenuMusic;
    public bool IsPlayGameMusic;

    public float GameScore;
    public float GameTime;
    public bool GameProcessIsOn;
    
    public GameResultData[] GameRes = new GameResultData[11];
    public GameConfiguration GameConfig = ScriptableObject.CreateInstance<GameConfiguration>();
    
    //public readonly int MaxRoadCount = 20;
    //public readonly int MaxStonesCount = 19;
    //public readonly float StartSpeed = 5f;
    public float Speed;
    public float Acceleration = 1;
    public bool Trigger = true;
    
    public void CreateStartRecordsList()
    {
        for (var i = 0; i < AppData.GameRes.Length; i++)
            AppData.GameRes[i] = new GameResultData();
    }
}

