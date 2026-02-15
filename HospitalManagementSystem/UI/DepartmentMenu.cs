using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;

namespace HospitalManagementSystem.UI
{
    public class DepartmentMenu
    {
        private DepartmentService _departmentService;
        private DoctorService _doctorService;

        public DepartmentMenu(DepartmentService departmentService, DoctorService doctorService)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
        }
        public void AddDepartment()
        {
            Console.Clear();
            Department department = new Department();
            Console.WriteLine("DEPARTMAN EKLEME");
            Console.WriteLine("----------------\n");
            department.Name = InputHelper.ReadString("Departman Adı : ");
            _departmentService.AddDepartment(department);
            Console.WriteLine("\nDepartman Başarıyla Eklendi!");
        }

        public void ListDepartments()
        {
            Console.Clear();
            var departments = _departmentService.GetAllDepartments();
            Console.WriteLine("DEPARTMAN LİSTESİ");
            Console.WriteLine("-----------------\n");
            if (departments.Count == 0)
            {
                Console.WriteLine("Henüz bir departman eklenmedi.");
            }
            else
            {
                foreach (var d in departments)
                {
                    Console.WriteLine($"Departman ID : {d.DepartmentId}\n" +
                        $"Departman Adı : {d.Name}");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                }
            }
        }
        public void ShowDepartmentsForSelection()
        {
            var departments = _departmentService.GetAllDepartments();

            Console.WriteLine("\nMEVCUT DEPARTMANLAR ;");
            ;
            foreach (var d in departments)
            {
                Console.WriteLine($"{d.DepartmentId} - {d.Name}");
            }

            Console.WriteLine();
        }

        public void UpdateDepartment()
        {
            Console.Clear();
            Console.WriteLine("DEPARTMAN GÜNCELLEME");
            Console.WriteLine("--------------------\n");

            ShowDepartmentsForSelection();
            int id = InputHelper.ReadInt("Departman Id : ");

            if (!_departmentService.DepartmentExists(id))
            {
                Console.WriteLine("\nBöyle bir departman bulunamadı!");
                return;
            }

            Department department = new Department();
            department.DepartmentId = id;

            department.Name = InputHelper.ReadString("Departman Adı : ");
            _departmentService.UpdateDepartment(department);
            Console.WriteLine("\nDepartman Başarıyla Güncellendi!");
        }

        public void DeleteDepartment()
        {
            Console.Clear();
            Console.WriteLine("DEPARTMAN SİLME");
            Console.WriteLine("---------------\n");

            ShowDepartmentsForSelection();
            int id = InputHelper.ReadInt("Departman Id : ");
            if (!_departmentService.DepartmentExists(id))
            {
                Console.WriteLine("\nBöyle bir departman bulunamadı!");
                return;
            }

            if (_doctorService.GetAllDoctors().Any(d => d.DepartmentId == id))
            {
                Console.WriteLine("\nBu departmana bağlı doktorlar olduğu için departman silinemedi!");
                return;
            }
            else
            {
                _departmentService.DeleteDepartment(id);
                Console.WriteLine("\nDepartman Başarıyla Silindi!");
            }

        }

    }
}
