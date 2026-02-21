using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class DepartmentService
    {
        private List<Department> _departments;
        private string _filePath = "departments.json";
        private int _idCounter = 1;

        public DepartmentService()
        {
            _departments = JsonHelper.LoadFromFile<Department>(_filePath);

            if (_departments.Any())
                _idCounter = _departments.Max(x => x.DepartmentId) + 1;
        }
        public void AddDepartment(Department department)
        {
            department.DepartmentId = _idCounter++;
            _departments.Add(department);
            JsonHelper.SaveToFile(_filePath, _departments);
        }

        public List<Department> GetAllDepartments()
        {
            return _departments;
        }

        public void UpdateDepartment(Department department)
        {
            var existingDepartment = _departments.FirstOrDefault(x => x.DepartmentId == department.DepartmentId);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
            }
            JsonHelper.SaveToFile(_filePath, _departments);
        }
        public void DeleteDepartment(int departmentId)
        {
            var department = _departments.FirstOrDefault(x => x.DepartmentId == departmentId);
            if (department != null)
            {
                _departments.Remove(department);
            }
            JsonHelper.SaveToFile(_filePath, _departments);
        }

        public bool DepartmentExists(int departmentId)
        {
            return _departments.Any(x => x.DepartmentId == departmentId);
        }

        public Department GetById(int Id)
        {
            return _departments.FirstOrDefault(x => x.DepartmentId == Id);
        }

        public bool HasDoctors(int departmentId, List<Doctor> doctors)
        {
            return doctors.Any(d => d.DepartmentId == departmentId);
        }
    }
}
