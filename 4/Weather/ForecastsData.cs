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
        /// <summary>
        /// Список данных о погоде в городе в разбивке по дате и премени
        /// </summary>
        public List<ForecastItem> List;
    }
}
