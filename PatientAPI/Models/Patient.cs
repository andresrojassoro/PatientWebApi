using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientAPI.Models
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Country Nationality { get; set; }
        public BloodType BloodType { get; set; }
        public string Diseases { get; set; }

        public Patient() {
            Nationality = new Country();
            BloodType = new BloodType();
        }
    }
}