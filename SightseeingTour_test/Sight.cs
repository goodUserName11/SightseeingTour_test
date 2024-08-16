using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SightseeingTour_test
{
    /// <summary>
    /// Достопримечательность
    /// </summary>
    internal class Sight
    {
        /// <summary>
        /// Название достопримечательности
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Затраты времени на посещение
        /// </summary>
        public double TimeConsumption { get; set; }
        /// <summary>
        /// Важность
        /// </summary>
        public int Significance { get; set; }
    }
}
