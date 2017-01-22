using Newtonsoft.Json;
using PatientAPI.DataAccess;
using PatientAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientController : ApiController
    {
        public async Task<List<Patient>> Get(string id="")
        {
            PatientDao dao = new PatientDao();
            if (string.IsNullOrWhiteSpace(id))
            {
                return dao.Get();
            }
            else
            {
                return dao.GetPatientById(id);
            }        
        }
        [System.Web.Http.HttpPost]
        public async Task Save(string JsonObj)
        {
            try
            {
                Patient patient = JsonConvert.DeserializeObject<Patient>(JsonObj);
                PatientDao dao = new PatientDao();
                if (string.IsNullOrWhiteSpace(patient.PatientId))
                {
                    dao.Create(patient);
                }
                else
                {
                    dao.Update(patient);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
     
        }
        [System.Web.Http.HttpPost]
        public async Task Delete(string id)
        {
            PatientDao dao = new PatientDao();
            dao.Delete(id);
        }
        public async Task<List<Country>> GetCountries()
        {
            PatientDao dao = new PatientDao();
            return dao.GetCountries();
        }
        public async Task<List<BloodType>> GetBloodTypes()
        {
            PatientDao dao = new PatientDao();
            return dao.GetBloodTypes();
        }
    }
}