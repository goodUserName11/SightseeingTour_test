using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightseeingTour_test
{
    /// <summary>
    /// Сопоставляет членов класса "Sight" с полем CSV
    /// </summary>
    internal class SightsMap : ClassMap<Sight>
    {
        public SightsMap() 
        {
            Map(m => m.Name).Name("Название достопримечательности");
            Map(m => m.TimeConsumption).TypeConverter<TimeConsumptionConverter>().Name("Затраты времени на посещение");
            Map(m => m.Significance).Name("Важность");

        }
    }
}
