using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightseeingTour_test
{
    /// <summary>
    /// Конвертирует строку для TimeConsumption и обратно
    /// </summary>
    internal class TimeConsumptionConverter : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            return double.Parse(text.Replace("ч", ""));
        }

        public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString() + "ч";
        }
    }
}
