using AspNetCoreExample6.Models;
using System.Collections.Generic;

namespace AspNetCoreExample6.Services
{
    public interface ISensorDataService
    {
        IntHistoryModel GetWaterTemperatureFahrenheit();
        IEnumerable<IntHistoryModel> GetWaterTemperatureFahrenheitHistory();
        IntHistoryModel GetFishMotionPercentage();
        IEnumerable<IntHistoryModel> GetFishMotionPercentageHistory();
        IntHistoryModel GetWaterOpacityPercentage();
        IEnumerable<IntHistoryModel> GetWaterOpacityPercentageHistory();
        IntHistoryModel GetLightIntensityLumens();
        IEnumerable<IntHistoryModel> GetLightIntensityLumensHistory();
    }
}
