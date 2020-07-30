using System;
using System.Collections.Generic;

namespace WaterConservation.Entities
{
    [Serializable]
    public class HarvestResultModel
    {
        public HarvestResultModel()
        {
            HarvestResult = new List<HarvestResultEntity>();
        }
        public List<HarvestResultEntity> HarvestResult { get; set; }
    }
}
