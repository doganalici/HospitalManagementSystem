using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class PatientService
    {
        private List<Patient> _patients = new List<Patient>();
        private int _idCounter = 1;

        public void AddPatient(Patient patient)
        {
            patient.PatientId = _idCounter++;
            _patients.Add(patient);
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
        }
        public void DeletePatient(int patientId)
        {
            var patient = _patients.FirstOrDefault(x => x.PatientId == patientId);

            if (patient != null)
            {
                _patients.Remove(patient);
            }
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
