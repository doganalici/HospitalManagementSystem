using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class DoctorService
    {
        private List<Doctor> _doctors;
        private string _filePath = "doctor.json";
        private int _idCounter = 1;

        public DoctorService()
        {
            _doctors = JsonHelper.LoadFromFile<Doctor>(_filePath);

            if (_doctors.Any())
                _idCounter = _doctors.Max(x => x.DoctorId) + 1;
        }
        public void AddDoctor(Doctor doctor)
        {
            doctor.DoctorId = _idCounter++;
            _doctors.Add(doctor);
            JsonHelper.SaveToFile(_filePath, _doctors);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctors.Where(x => x.IsActive).ToList();
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
            JsonHelper.SaveToFile(_filePath, _doctors);
        }

        public string DeleteDoctor(int doctorId)
        {
            var doctor = _doctors.FirstOrDefault(x => x.DoctorId == doctorId);
            if (doctor == null)
                return "Doktor bulunamadı.";

            doctor.IsActive = false;
            JsonHelper.SaveToFile(_filePath, _doctors);

            return "Doktor pasif yapıldı.";
        }

        public bool DoctorExists(int doctorId)
        {
            return _doctors.Any(x => x.DoctorId == doctorId);
        }

        public Doctor GetById(int id)
        {
            return _doctors.FirstOrDefault(d => d.DoctorId == id);
        }

        public List<Doctor> GetDoctorsByDepartment(int departmentId)
        {
            return _doctors
                .Where(d => d.DepartmentId == departmentId && d.IsActive)
                .ToList();
        }
    }
}
