using System;

namespace WaterConservation.Entities
{
    [Serializable]
    public class TotalGroundWaterPresentationEntity
    {
        public TotalGroundWaterPresentationEntity(string _districtName, double? _totalAnnualGroundWaterQuantity)
        {
            this.DistrictName = _districtName;
            this.TotalAnnualGroundWaterQuantity = _totalAnnualGroundWaterQuantity;
        }
        public string DistrictName { get; set; }
        public double? TotalAnnualGroundWaterQuantity { get; set; }
    }
}
