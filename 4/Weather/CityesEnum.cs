using System;

namespace Weather
{        
    // Список городов, для которых реализована возможность получения погоды
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
