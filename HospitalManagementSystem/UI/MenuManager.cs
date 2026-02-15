using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HospitalManagementSystem.UI
{
    public class MenuManager
    {
        private PatientService _patientService;
        private DoctorService _doctorService;
        private AppointmentService _appointmentService;
        private DepartmentService _departmentService;

        private PatientMenu _patientMenu;
        private DoctorMenu _doctorMenu;
        private AppointmentMenu _appointmentMenu;
        private DepartmentMenu _departmentMenu;


        public MenuManager()
        {
            _patientService = new PatientService();
            _doctorService = new DoctorService();
            _appointmentService = new AppointmentService(_patientService, _doctorService);
            _departmentService = new DepartmentService();

            _patientMenu = new PatientMenu(_patientService);
            _doctorMenu = new DoctorMenu(_doctorService, _departmentService);
            _appointmentMenu = new AppointmentMenu(_appointmentService, _patientService, _doctorService);
            _departmentMenu = new DepartmentMenu(_departmentService, _doctorService);


        }

        private void ShowHeader()
        {
            Console.WriteLine("\t HASTANE YÖNETİM SİSTEMİ");
            Console.WriteLine("\t========================\n");
        }

        private void ShowMenu()
        {
            Console.WriteLine("1 - Hasta Ekle");
            Console.WriteLine("2 - Hastaları Listele");
            Console.WriteLine("3 - Hasta Güncelle");
            Console.WriteLine("4 - Hasta Sil\n");

            Console.WriteLine("5 - Doktor Ekle");
            Console.WriteLine("6 - Doktorları Listele");
            Console.WriteLine("7 - Doktor Güncelle");
            Console.WriteLine("8 - Doktor Sil\n");

            Console.WriteLine("9 - Randevu Ekle");
            Console.WriteLine("10 - Randevuları Listele");
            Console.WriteLine("11 - Randevu Güncelle");
            Console.WriteLine("12 - Randevu Sil\n");

            Console.WriteLine("13 - Departman Ekle");
            Console.WriteLine("14 - Departmanları Listele");
            Console.WriteLine("15 - Departman Güncelle");
            Console.WriteLine("16 - Departman Sil\n");

            Console.WriteLine("17 - Çıkış");
        }

        public static void Clear()
        {
            Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
            Console.ReadKey();
            Console.Clear();
        }
        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                ShowHeader();
                ShowMenu();

                Console.Write("\nSeçiminiz : ");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Hatalı giriş! Tekrar gir: ");
                }

                switch (option)
                {
                    case 1:
                        _patientMenu.AddPatient();
                        Clear();
                        break;

                    case 2:
                        _patientMenu.ListPatients();
                        Clear();
                        break;

                    case 3:
                        _patientMenu.UpdatePatient();
                        Clear();
                        break;

                    case 4:
                        _patientMenu.DeletePatient();
                        Clear();
                        break;

                    case 5:
                        _doctorMenu.AddDoctor();
                        Clear();
                        break;

                    case 6:
                        _doctorMenu.ListDoctors();
                        Clear();
                        break;

                    case 7:
                        _doctorMenu.UpdateDoctor();
                        Clear();
                        break;

                    case 8:
                        _doctorMenu.DeleteDoctor();
                        Clear();
                        break;

                    case 9:
                        _appointmentMenu.AddAppointment();
                        Clear();
                        break;

                    case 10:
                        _appointmentMenu.ListAppointments();
                        Clear();
                        break;

                    case 11:
                        _appointmentMenu.UpdateAppointment();
                        Clear();
                        break;

                    case 12:
                        _appointmentMenu.DeleteAppointment();
                        Clear();
                        break;

                    case 13:
                        _departmentMenu.AddDepartment();
                        Clear();
                        break;

                    case 14:
                        _departmentMenu.ListDepartments();
                        Clear();
                        break;

                    case 15:
                        _departmentMenu.UpdateDepartment();
                        Clear();
                        break;

                    case 16:
                        _departmentMenu.DeleteDepartment();
                        Clear();
                        break;

                    case 17:
                        Clear();
                        Console.WriteLine("Çıkış yapılıyor...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        Clear();
                        break;
                }
            }
        }

    }
}
