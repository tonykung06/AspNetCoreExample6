using AspNetCoreExample6.Models;
using AspNetCoreExample6.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreExample6.Controllers.Api
{
    public class HistoryDataController : Controller
    {
        private readonly ISensorDataService sensorDataService;

        public HistoryDataController(ISensorDataService sensorDataService)
        {
            this.sensorDataService = sensorDataService;
        }

        public IEnumerable<IntHistoryModel> GetWaterTemperatureHistory()
        {
            return sensorDataService.GetWaterTemperatureFahrenheitHistory();
        }

        public IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory()
        {
            return sensorDataService.GetFishMotionPercentageHistory();
        }

        public IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory()
        {
            return sensorDataService.GetWaterOpacityPercentageHistory();
        }
        public IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory()
        {
            return sensorDataService.GetLightIntensityLumensHistory();
        }
    }
}
