using System;

namespace Weather
{
    /// <summary>
    /// Список городов, для которых реализована возможность получения погоды
    /// </summary>
    [Serializable]
    public enum CityNamesEnum
    {
        Moscow = 1,
        Berlin,
        London,
        Minsk,
        Paris,
        Other
    }    
}
