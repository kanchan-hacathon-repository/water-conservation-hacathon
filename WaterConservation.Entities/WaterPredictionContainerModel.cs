using System;
using System.Collections.Generic;

namespace WaterConservation.Entities
{
    [Serializable]
    public class WaterPredictionContainerModel
    {
        public WaterPredictionContainerModel()
        {
            predictionModel = new List<WaterPredictionModel>();
        }
        public List<WaterPredictionModel> predictionModel { get; set; }
    }
}
