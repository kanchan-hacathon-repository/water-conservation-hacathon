using System;
using System.Collections.Generic;

namespace WaterConservation.Entities
{
    [Serializable]
    public class DistrictWiseGroundWaterPresentationModel
    {
        public DistrictWiseGroundWaterPresentationModel()
        {
            AllDistrictsStateQuantity = new List<TotalGroundWaterPresentationEntity>();
        }
        public List<TotalGroundWaterPresentationEntity> AllDistrictsStateQuantity { get; set; }
    }
    
}
