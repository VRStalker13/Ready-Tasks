using System;
using System.Collections.Generic;

namespace Weather
{
    /// <summary>
    /// Класс в котором храняться данные о погоде за помежуток времени
    /// </summary>
    [Serializable]    
    public class ForecastsData
    {
        public List<ForecastItem> List;
    }
}
