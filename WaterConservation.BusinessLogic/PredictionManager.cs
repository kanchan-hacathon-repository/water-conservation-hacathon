using System;
using System.Collections.Generic;
using WaterConservation.Entities;

namespace WaterConservation.BusinessLogic
{
    public class PredictionManager
    {
        public List<AvarageYearlyCountryStorage> GetYearlyStorage(double? totalStorageForCountry, int count)
        {           
            List<AvarageYearlyCountryStorage> resultList = new List<AvarageYearlyCountryStorage>();
            var avarageStoragePerState2017 = totalStorageForCountry / count;
            var avarageStoragePerState2018 = (avarageStoragePerState2017 - (avarageStoragePerState2017 * 3.5) / 100);
            var avarageStoragePerState2019 = (avarageStoragePerState2018 - (avarageStoragePerState2018 * 3.5) / 100);
            var avarageStoragePerState2020 = (avarageStoragePerState2019 - (avarageStoragePerState2019 * 3.5) / 100);
            var avarageStoragePerState2021 = (avarageStoragePerState2020 - (avarageStoragePerState2020 * 3.5) / 100);
            var avarageStoragePerState2022 = (avarageStoragePerState2021 - (avarageStoragePerState2021 * 3.5) / 100);
            var avarageStoragePerState2023 = (avarageStoragePerState2022 - (avarageStoragePerState2022 * 3.5) / 100);
            var avarageStoragePerState2024 = (avarageStoragePerState2023 - (avarageStoragePerState2023 * 3.5) / 100);
            var avarageStoragePerState2025 = (avarageStoragePerState2024 - (avarageStoragePerState2024 * 3.5) / 100);
            var avarageStoragePerState2026 = (avarageStoragePerState2025 - (avarageStoragePerState2025 * 3.5) / 100);

            resultList.Add(new AvarageYearlyCountryStorage(2017, avarageStoragePerState2017.HasValue ? (double?)Math.Round(avarageStoragePerState2017.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2018, avarageStoragePerState2018.HasValue ? (double?)Math.Round(avarageStoragePerState2018.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2019, avarageStoragePerState2019.HasValue ? (double?)Math.Round(avarageStoragePerState2019.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2020, avarageStoragePerState2020.HasValue ? (double?)Math.Round(avarageStoragePerState2020.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2021, avarageStoragePerState2021.HasValue ? (double?)Math.Round(avarageStoragePerState2021.Value) : 0));

            resultList.Add(new AvarageYearlyCountryStorage(2022, avarageStoragePerState2022.HasValue ? (double?)Math.Round(avarageStoragePerState2022.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2023, avarageStoragePerState2023.HasValue ? (double?)Math.Round(avarageStoragePerState2023.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2024, avarageStoragePerState2024.HasValue ? (double?)Math.Round(avarageStoragePerState2024.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2025, avarageStoragePerState2025.HasValue ? (double?)Math.Round(avarageStoragePerState2025.Value) : 0));
            resultList.Add(new AvarageYearlyCountryStorage(2026, avarageStoragePerState2026.HasValue ? (double?)Math.Round(avarageStoragePerState2026.Value) : 0));

            return resultList;
        }
    }
}
