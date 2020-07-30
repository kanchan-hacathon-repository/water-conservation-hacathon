namespace WaterConservation.Entities
{
    public class WaterPredictionModel
    {
        public WaterPredictionModel(long _sNo, string _nameOfState, string _nameOfDistrict, double? _rechargeFromRainfallDuringMonsoonSeason,
           double? _rechargeFromOtherSourcesDuringMonsoonSeason, double? _rechargeFromRainfallDuringNonMonsoonSeason, 
           double? _rechargeFromOtherSourcesDuringNonMonsoonSeason, double? _totalAnnualGroundWaterRecharge,
           double? _totalNaturalDischarges, double? _annualExtractableGroundWaterResource,
           double? _currentAnnualGroundWaterExtractionForIrrigation, double _currentAnnualGroundWaterExtractionForDomesticIndustrial,
           double? _totalCurrentAnnualGroundWaterExtraction, double? _annualGwAllocationForDomesticUseAsOn2025,
           double? _netGroundWaterAvailabilityForFutureUse, double? _stageOfGroundWaterExtraction)
        {
            this.SNo = _sNo;
            this.NameOfState = _nameOfState;
            this.NameOfDistrict = _nameOfDistrict;
            this.RechargeFromRainfallDuringMonsoonSeason = _rechargeFromRainfallDuringMonsoonSeason;
            this.RechargeFromOtherSourcesDuringMonsoonSeason = _rechargeFromOtherSourcesDuringMonsoonSeason;
            this.RechargeFromRainfallDuringNonMonsoonSeason = _rechargeFromRainfallDuringNonMonsoonSeason;
            this.RechargeFromOtherSourcesDuringNonMonsoonSeason = _rechargeFromOtherSourcesDuringNonMonsoonSeason;
            this.TotalAnnualGroundWaterRecharge = _totalAnnualGroundWaterRecharge;
            this.TotalNaturalDischarges = _totalNaturalDischarges;
            this.AnnualExtractableGroundWaterResource = _annualExtractableGroundWaterResource;
            this.CurrentAnnualGroundWaterExtractionForIrrigation = _currentAnnualGroundWaterExtractionForIrrigation;
            this.CurrentAnnualGroundWaterExtractionForDomesticIndustrial = _currentAnnualGroundWaterExtractionForDomesticIndustrial;
            this.TotalCurrentAnnualGroundWaterExtraction = _totalCurrentAnnualGroundWaterExtraction;
            this.AnnualGwAllocationForDomesticUseAsOn2025 = _annualGwAllocationForDomesticUseAsOn2025;
            this.NetGroundWaterAvailabilityForFutureUse = _netGroundWaterAvailabilityForFutureUse;
            this.StageOfGroundWaterExtraction = _stageOfGroundWaterExtraction;
        }
        public long SNo { get; set; }       
        public string NameOfState { get; set; }
        public string NameOfDistrict { get; set; }
        public double? RechargeFromRainfallDuringMonsoonSeason { get; set; }
        public double? RechargeFromOtherSourcesDuringMonsoonSeason { get; set; }
        public double? RechargeFromRainfallDuringNonMonsoonSeason { get; set; }
        public double? RechargeFromOtherSourcesDuringNonMonsoonSeason { get; set; }
        public double? TotalAnnualGroundWaterRecharge { get; set; }
        public double? TotalNaturalDischarges { get; set; }
        public double? AnnualExtractableGroundWaterResource { get; set; }
        public double? CurrentAnnualGroundWaterExtractionForIrrigation { get; set; }
        public double CurrentAnnualGroundWaterExtractionForDomesticIndustrial { get; set; }
        public double? TotalCurrentAnnualGroundWaterExtraction { get; set; }
        public double? AnnualGwAllocationForDomesticUseAsOn2025 { get; set; }
        public double? NetGroundWaterAvailabilityForFutureUse { get; set; }
        public double? StageOfGroundWaterExtraction { get; set; }
    }
}

