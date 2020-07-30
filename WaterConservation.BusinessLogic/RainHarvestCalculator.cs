using System.Collections.Generic;
using WaterConservation.Entities;

namespace WaterConservation.BusinessLogic
{
    public class RainHarvestCalculator
    {
        int _harvestConstant = 623;
        List<decimal> rainFallMeterForGraph = new List<decimal>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public RainHarvestCalculator()
        {

        }

        public decimal CalculateHarvest(decimal numArea, decimal numRainFall, decimal numEfficiency, decimal numCollectionPoints)
        {
            decimal totalVolume = ((numArea * numRainFall * numEfficiency) * _harvestConstant);
            return (totalVolume / 1000) * numCollectionPoints;
        }

        public List<HarvestResultEntity> HarvestChartCalculator(decimal numArea, decimal numRainFall, decimal numEfficiency, decimal numCollectionPoints)
        {
            HarvestResultModel resultModel = new HarvestResultModel();

            foreach (decimal rainFall in rainFallMeterForGraph)
            {
                resultModel.HarvestResult.Add(new HarvestResultEntity(rainFall, CalculateHarvest(numArea, rainFall, numEfficiency, numCollectionPoints)));
            }
            return resultModel.HarvestResult;
        }
    }
}
