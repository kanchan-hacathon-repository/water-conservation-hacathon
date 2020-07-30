using System;

namespace WaterConservation.Entities
{
    [Serializable]
    public class HarvestResultEntity
    {
        public HarvestResultEntity(decimal rainfall, decimal harvest)
        {
            this.RainFall = rainfall;
            this.Harvest = harvest;
        }
        public decimal RainFall { get; set; }
        public decimal Harvest { get; set; }
    }
}
