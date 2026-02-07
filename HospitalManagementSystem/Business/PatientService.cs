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
        public void AddPatient(Patient patient)
        {
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
    }
}
