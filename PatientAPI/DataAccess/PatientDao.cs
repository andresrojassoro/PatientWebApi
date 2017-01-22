using PatientAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PatientAPI.DataAccess
{
    public class PatientDao
    {
        public List<Patient> Get()
        {
            List<Patient> list = new List<Patient>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = "uspGetPatients";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();

                Patient p;
        
                while (reader.Read())
                {
                    p = new Patient();
                    p.PatientId = (string)reader["PatientId"].ToString();
                    p.FirstName = (string)reader["FirstName"].ToString();
                    p.LastName = (string)reader["LastName"].ToString();
                    p.PhoneNumber = (string)reader["PhoneNumber"].ToString();
                  //  p.DateOfBirth = (DateTime)reader["DateOfBirth"];
                   
                    if (!string.IsNullOrEmpty(reader["CountryID"].ToString()))
                    {
                        Country nationality = new Country();
                        nationality.Id = (int)reader["CountryID"];
                        nationality.Name = (string)reader["CountryName"];
                        p.Nationality = nationality;
                    }
                    if (!string.IsNullOrEmpty(reader["BloodTypeId"].ToString()))
                    {
                        BloodType bloodType = new BloodType();
                        bloodType.Id = (int)reader["BloodTypeId"];
                        bloodType.Name = (string)reader["BloodTypeName"].ToString();
                        p.BloodType = bloodType;
                    }
                    list.Add(p);
                }

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }

        public List<Patient> GetPatientById(string id)
        {
            List<Patient> list = new List<Patient>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                cmd.CommandText = "uspGetPatientById";
                cmd.Parameters.Add("@PatientId", SqlDbType.VarChar).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();

                Patient p;

                while (reader.Read())
                {
                    p = new Patient();
                    p.PatientId = (string)reader["PatientId"].ToString();
                    p.FirstName = (string)reader["FirstName"].ToString();
                    p.LastName = (string)reader["LastName"].ToString();
                    p.PhoneNumber = (string)reader["PhoneNumber"].ToString();
                    //  p.DateOfBirth = (DateTime)reader["DateOfBirth"];

                    if (!string.IsNullOrEmpty(reader["CountryID"].ToString()))
                    {
                        Country nationality = new Country();
                        nationality.Id = (int)reader["CountryID"];
                        nationality.Name = (string)reader["CountryName"];
                        p.Nationality = nationality;
                    }
                    if (!string.IsNullOrEmpty(reader["BloodTypeId"].ToString()))
                    {
                        BloodType bloodType = new BloodType();
                        bloodType.Id = (int)reader["BloodTypeId"];
                        bloodType.Name = (string)reader["BloodTypeName"].ToString();
                        p.BloodType = bloodType;
                    }
                    list.Add(p);
                }

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }

        public void Create(Patient patient) {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspCreatePatient";
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = patient.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = patient.LastName;
                cmd.Parameters.Add("@IdNumber", SqlDbType.VarChar).Value = patient.IdNumber;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = patient.PhoneNumber;
                cmd.Parameters.Add("@Diseases", SqlDbType.VarChar).Value = patient.Diseases;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = patient.Nationality.Id;
                cmd.Parameters.Add("@BloodTypeId", SqlDbType.Int).Value = patient.BloodType.Id;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteReader();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(Patient patient)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspUpdatePatient";
                cmd.Parameters.Add("@PatientId", SqlDbType.VarChar).Value = patient.PatientId;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = patient.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = patient.LastName;
                cmd.Parameters.Add("@IdNumber", SqlDbType.VarChar).Value = patient.IdNumber;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = patient.PhoneNumber;
                cmd.Parameters.Add("@Diseases", SqlDbType.VarChar).Value = patient.Diseases;
                cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = patient.Nationality.Id;
                cmd.Parameters.Add("@BloodTypeId", SqlDbType.Int).Value = patient.BloodType.Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteReader();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspDeletePatient";
                cmd.Parameters.Add("@PatientId", SqlDbType.VarChar).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                cmd.ExecuteReader();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<Country> GetCountries()
        {
            List<Country> list = new List<Country>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspGetCountries";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                Country c;

                while (reader.Read())
                {
                    c = new Country();
                    c.Id = (int)reader["CountryId"];
                    c.Name = (string)reader["CountryName"].ToString();
                    list.Add(c);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
        public List<BloodType> GetBloodTypes()
        {
            List<BloodType> list = new List<BloodType>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PatientsDB"].ConnectionString;
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "uspGetBloodTypes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnection1;
                sqlConnection1.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                BloodType b;

                while (reader.Read())
                {
                    b = new BloodType();
                    b.Id = (int)reader["BloodTypeId"];
                    b.Name = (string)reader["BloodTypeName"].ToString();
                    list.Add(b);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return list;
        }
    }
}