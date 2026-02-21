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
    public class DoctorMenu
    {
        private DoctorService _doctorService;
        private DepartmentService _departmentService;


        public DoctorMenu(DoctorService doctorService, DepartmentService departmentService)
        {
            _doctorService = doctorService;
            _departmentService = departmentService;
        }

        public void AddDoctor()
        {
            Console.Clear();

            var departments = _departmentService.GetAllDepartments();
            if (departments.Count == 0)
            {
                Console.WriteLine("Öncelikle bir departman eklemeniz gerekiyor!");
                return;
            }
            Doctor doctor = new Doctor();
            Console.WriteLine("DOKTOR EKLEME");
            Console.WriteLine("-------------\n");

            doctor.FirstName = InputHelper.ReadString("Doktor Adı : ");

            doctor.LastName = InputHelper.ReadString("Doktor Soyadı : ");

            ShowDepartmentsForSelection();
            int depId;

            while (true)
            {
                depId = InputHelper.ReadInt("Doktor Departman Id : ");
                if (_departmentService.DepartmentExists(depId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Departman Id! Lütfen geçerli bir departman Id giriniz.");
            }

            doctor.DepartmentId = depId;

            _doctorService.AddDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Eklendi!");
        }

        public void ListDoctors()
        {
            Console.Clear();
            var doctors = _doctorService.GetAllDoctors();

            Console.WriteLine("DOKTOR LİSTESİ");
            Console.WriteLine("--------------\n");

            if (doctors.Count == 0)
            {
                Console.WriteLine("Henüz bir doktor eklenmedi.");
            }
            else
            {
                foreach (var d in doctors)
                {
                    var department = _departmentService
        .GetAllDepartments()
        .FirstOrDefault(x => x.DepartmentId == d.DepartmentId);

                    string departmentName = department != null ? department.Name : "Bilinmiyor";

                    Console.WriteLine(
                        $"Doktor Adı Soyadı : {(d.FirstName + " " + d.LastName).ToUpper() + " (ID : " + d.DoctorId + ")"}\n" +
                        $"Departman : {departmentName + " (ID : " + d.DepartmentId + ")"}"
                    );
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                }
            }
        }
        public void ShowDoctorsForSelection()
        {
            var doctors = _doctorService.GetAllDoctors();
            Console.WriteLine("\nMEVCUT DOKTORLAR ;");
            ;
            foreach (var d in doctors)
            {
                var department = _departmentService
    .GetAllDepartments()
    .FirstOrDefault(x => x.DepartmentId == d.DepartmentId);

                string departmentName = department != null ? department.Name : "Bilinmiyor";

                Console.WriteLine(
                    $"Doktor Adı Soyadı : {(d.FirstName + " " + d.LastName).ToUpper() + " (ID : " + d.DoctorId + ")"}\n" +
                    $"Departman : {departmentName}"
                );
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine();
            }
        }

        public void UpdateDoctor()
        {
            Console.Clear();
            Console.WriteLine("DOKTOR GÜNCELLEME");
            Console.WriteLine("-----------------\n");

            ShowDoctorsForSelection();

            int id = InputHelper.ReadInt("Doktor Id : ");
            if (!_doctorService.DoctorExists(id))
            {
                Console.WriteLine("\nBöyle bir doktor bulunamadı!");
                return;
            }


            Doctor doctor = new Doctor();
            doctor.DoctorId = id;

            doctor.FirstName = InputHelper.ReadString("Doktor Adı : ");

            doctor.LastName = InputHelper.ReadString("Doktor Soyadı : ");

            ShowDepartmentsForSelection();
            int depId;
            while (true)
            {
                depId = InputHelper.ReadInt("Doktor Departman Id : ");
                if (_departmentService.DepartmentExists(depId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Departman Id! Lütfen geçerli bir departman Id giriniz.");
            }
            doctor.DepartmentId = depId;

            _doctorService.UpdateDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Güncellendi!");
        }

        public void DeleteDoctor()
        {
            Console.Clear();
            Console.WriteLine("DOKTOR SİLME");
            Console.WriteLine("------------");

            ShowDoctorsForSelection();
            int id = InputHelper.ReadInt("Doktor Id : ");
            if (!_doctorService.DoctorExists(id))
            {
                Console.WriteLine("\nBöyle bir doktor bulunamadı!");
                return;
            }

            _doctorService.DeleteDoctor(id);

            Console.WriteLine("\nDoktor Başarıyla Silindi!");
        }

        private void ShowDepartmentsForSelection()
        {
            var departments = _departmentService.GetAllDepartments();

            Console.WriteLine("\nMEVCUT DEPARTMANLAR ;");

            if (departments.Count == 0)
            {
                Console.WriteLine("Henüz departman eklenmedi.");
                return;
            }

            foreach (var d in departments)
            {
                Console.WriteLine($"{d.DepartmentId} - {d.Name}");
            }

            Console.WriteLine();
        }
    }
}
