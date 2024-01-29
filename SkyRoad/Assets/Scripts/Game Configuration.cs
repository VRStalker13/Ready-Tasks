using UnityEngine;

[CreateAssetMenu(fileName = "New GameConfig", menuName = "GameConfig", order = 51)]
public class GameConfiguration : ScriptableObject
{
    public int MaxRoadCount = 20;
    public int MaxStonesCount = 19;
    public float StartSpeed = 5f;
}
