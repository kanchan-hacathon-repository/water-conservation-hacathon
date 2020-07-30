using System;

namespace WaterConservation.Entities
{
    [Serializable]
    public class AvarageYearlyCountryStorage
    {
        public AvarageYearlyCountryStorage(int _year, double? _avarageStorage)
        {
            this.Year = _year;
            this.AvarageStorage = _avarageStorage;
        }
        public int Year { get; set; }
        public double? AvarageStorage { get; set; }
    }
}
