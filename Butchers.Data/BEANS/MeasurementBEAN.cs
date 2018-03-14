using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class MeasurementBEAN
    {
        [Display(Name = "Measurement Id")]
        public int MeasurementId { get; set; }

        [Display(Name = "Measurement Name")]
        public string MeasurementName { get; set; }

        [Display(Name = "Grams Per")]
        public decimal? GramsPerMeasurement { get; set; }

        public MeasurementBEAN() { }
    }
}
