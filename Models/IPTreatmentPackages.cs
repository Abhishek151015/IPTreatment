using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPTreatment.Models
{
    public class IPTreatmentPackages
    {
        public string AilmentCategory { get; set; }
        public string TreatmentPackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int TreatmentDuration { get; set; }

    }
}
