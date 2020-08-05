using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IPTreatment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;


namespace IPTreatment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulateTreatmentTimetableController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(FormulateTreatmentTimetableController));
        public static List<TreatmentPlan> treatmentPlans = new List<TreatmentPlan>();

        public static List<PatientDetail> patientDetails = new List<PatientDetail>();
     
        TreatmentPlan t = new TreatmentPlan();

     
        [HttpPost]
        public async Task<TreatmentPlan> Post(PatientDetail details)
        {
            _log4net.Info("FormulateTreatmentController Get Method");

            IPTreatmentPackages packages = new IPTreatmentPackages();
            SpecialistDetail specialist = new SpecialistDetail();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64484/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("api/IPTreatmentPackages/").Result;
              
                var data = response.Content.ReadAsAsync<IEnumerable<IPTreatmentPackages>>().Result;
                foreach (var x in data)
                {
                    if (x.AilmentCategory == details.Ailment && x.TreatmentPackageName.ToString() == details.Packages.ToString())
                    {
                        t.PackageName = x.TreatmentPackageName;
                        t.TestDetails = x.TestDetails;
                        t.Cost = x.Cost;
                        t.CommencementDate = details.Date;
                        t.EndDate = t.CommencementDate.AddDays(x.TreatmentDuration);
                    }
                }

                HttpResponseMessage response1 = new HttpResponseMessage();
                response1 = client.GetAsync("api/SpecialistDetail/").Result;
               
                var data1 = response1.Content.ReadAsAsync<IEnumerable<SpecialistDetail>>().Result;
                foreach (var y in data1)
                {
                    if (y.AreaOfExpertise == details.Ailment)
                    {
                        t.Specialist = y.Name;
                       

                    }
                }
            
                return t;


            }


        }
    }

}