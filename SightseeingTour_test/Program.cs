using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Xml.Schema;

namespace SightseeingTour_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Всего времени
            double totalTime = 48 - (8 * 2);
            // Массив достопримечательностей
            List<Sight> sights;

            // Файл с данными
            string dataFile = @"./data.csv";
            
            // Конфигурация парсера csv
            var config = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
            {
                Delimiter = "\t",
                HasHeaderRecord = true,
            };

            // Парсинг файла с данными
            TextReader reader = new StreamReader(dataFile);
            using (CsvReader csvReader = new CsvReader(reader, config))
            {
                csvReader.Context.RegisterClassMap<SightsMap>();

                sights = csvReader.GetRecords<Sight>().ToList();
            }

            // Список достопримечательностей на оптимальном маршруте
            var optimalSights = OptimalTour(sights, totalTime);

            // Печать оптимального маршрута
            for (var i = 0; i < optimalSights.Count; i++) 
            {
                var sight = optimalSights[i];

                Console.WriteLine($"{i+1}. {sight.Name}");
            }
        }

        /// <summary>
        /// Определение оптимального маршрута
        /// </summary>
        /// <param name="allSights">Все достопримечательности</param>
        /// <param name="totalTime">Доступное время</param>
        /// <returns>Список достопримечательностей на оптимальном маршруте</returns>
        static List<Sight> OptimalTour(List<Sight> allSights, double totalTime)
        {
            // Список достопримечательностей на оптимальном маршруте
            var optimalSights = new List<Sight>();

            // Сортировка списка достопримечательностей по важности
            List<Sight> sortedSights = allSights
                .OrderByDescending(s => s.Significance)
                .ToList();

            // Проход по списку достопримечательностей
            foreach (var sight in sortedSights)
            {
                // Если достопримечательность помещается во время добавляем в маршрут, иначе берем следующую
                if (totalTime - sight.TimeConsumption > 0)
                {
                    totalTime -= sight.TimeConsumption;
                    optimalSights.Add(sight);
                }
                else continue;
            }

            return optimalSights;
        }
    }
}
