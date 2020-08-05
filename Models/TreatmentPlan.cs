using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPTreatment.Models
{
    public class TreatmentPlan
    {
        [DisplayName("Package Name")]
        public string PackageName { get; set; }
        [DisplayName("Test Details")]
        public string TestDetails { get; set; }
        [DisplayName("Cost")]
        public double Cost { get; set; }
        [DisplayName("Specialist Details")]
        public string Specialist { get; set; }
        [DisplayName("Treatment Commencement Date")]
        public DateTime CommencementDate { get; set; }
        [DisplayName("Treatmet End Date")]
        public DateTime EndDate { get; set; }

    }
}
