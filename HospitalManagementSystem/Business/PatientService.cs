using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class PatientService
    {
        private List<Patient> _patients;
        private string _filePath = "patients.json";
        private int _idCounter = 1;

        public PatientService()
        {
            _patients = JsonHelper.LoadFromFile<Patient>(_filePath);
            Console.WriteLine("Constructor çalıştı");
            Console.WriteLine(_patients == null ? "NULL" : "DOLU");
        }
        public void AddPatient(Patient patient)
        {

            _patients = JsonHelper.LoadFromFile<Patient>(_filePath);

            if (_patients.Count == 0)
                patient.PatientId = 1;
            else
                patient.PatientId = _patients.Max(x => x.PatientId) + 1;

            _patients.Add(patient);

            JsonHelper.SaveToFile(_filePath, _patients);
        }

        public List<Patient> GetAllPatients()
        {
            return _patients;

        }

        public void UpdatePatient(Patient patient)
        {
            var existingPatient = _patients.FirstOrDefault(x => x.PatientId == patient.PatientId);

            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.Phone = patient.Phone;
                existingPatient.BirthDate = patient.BirthDate;
                existingPatient.Gender = patient.Gender;
            }
            JsonHelper.SaveToFile(_filePath, _patients);
        }
        public void DeletePatient(int patientId)
        {
            var patient = _patients.FirstOrDefault(x => x.PatientId == patientId);

            if (patient != null)
            {
                _patients.Remove(patient);
            }
            JsonHelper.SaveToFile(_filePath, _patients);
        }

        public bool PatientExists(int patientId)
        {
            return _patients.Any(x => x.PatientId == patientId);
        }

        public Patient GetById(int id)
        {
            return _patients.FirstOrDefault(p => p.PatientId == id);
        }
    }
}
