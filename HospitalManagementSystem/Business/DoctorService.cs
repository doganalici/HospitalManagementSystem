using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class DoctorService
    {
        private List<Doctor> _doctors = new List<Doctor>();
        private int _idCounter = 1;

        public void AddDoctor(Doctor doctor)
        {
            doctor.DoctorId = _idCounter++;
            _doctors.Add(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctors;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = _doctors.FirstOrDefault(x => x.DoctorId == doctor.DoctorId);
            if (existingDoctor != null)
            {
                existingDoctor.DepartmentId = doctor.DepartmentId;
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
            }
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _doctors.FirstOrDefault(x => x.DoctorId == doctorId);
            if (doctor != null)
            {
                _doctors.Remove(doctor);
            }
        }

        public bool DoctorExists(int doctorId)
        {
            return _doctors.Any(x => x.DoctorId == doctorId);
        }
    }
}
