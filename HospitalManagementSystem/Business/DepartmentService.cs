using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class DepartmentService
    {
        private List<Department> _departments = new List<Department>();

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
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
        }
        public void DeleteDepartment(int departmentId)
        {
            var department = _departments.FirstOrDefault(x => x.DepartmentId == departmentId);
            if (department != null)
            {
                _departments.Remove(department);
            }
        }
    }
}
