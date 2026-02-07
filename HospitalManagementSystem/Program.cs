using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t HASTANE YÖNETİM SİSTEMİ");
            Console.WriteLine("\t========================");

            PatientService patientService = new PatientService();
            DoctorService doctorService = new DoctorService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Menüden tuşlama yapınız\n");
                Console.WriteLine("1 - Hasta Ekle\n" +
                    "2 - Hastaları Listele\n" +
                    "3 - Hasta Güncelleme\n" +
                    "4 - Hasta Sil\n" +

                    "5 - Doktor Ekle\n" +
                    "6 - Doktorları Listele\n" +
                    "7 - Doktor Güncelle\n" +
                    "8 - Doktor Sil\n" +

                    "9 - Çıkış");

                Console.Write("Seçiminiz : ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        AddPatient(patientService);
                        Clear();
                        break;

                    case 2:
                        Console.Clear();
                        ListPatients(patientService);
                        Clear();
                        break;

                    case 3:
                        Console.Clear();
                        UpdatePatient(patientService);
                        Clear();
                        break;

                    case 4:
                        Console.Clear();
                        DeletePatient(patientService);
                        Clear();
                        break;


                    case 5:
                        Console.Clear();
                        AddDoctor(doctorService);
                        Clear();
                        break;
                    case 6:
                        Console.Clear();
                        ListDoctors(doctorService);
                        Clear();
                        break;
                    case 7:
                        Console.Clear();
                        UpdateDoctor(doctorService);
                        Clear();
                        break;
                    case 8:
                        Console.Clear();
                        DeleteDoctor(doctorService);
                        Clear();
                        break;



                    case 9:
                        Console.Write("Çıkış yapılıyor... Lütfen bir tuşa basınız");
                        isRunning = false;
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\t HASTANE YÖNETİM SİSTEMİ");
                        Console.WriteLine("\t========================");
                        Console.WriteLine("Menü dışındaki bir rakam tuşlaması yaptınız. Lütfen tekrar deneyin!!!\n");
                        break;
                }
            }
        }
        static void AddPatient(PatientService service)
        {
            Console.Clear();
            Patient patient = new Patient();
            Console.WriteLine("HASTA EKLEME");
            Console.WriteLine("------------\n");

            Console.Write("Hasta ID : ");
            patient.PatientId = int.Parse(Console.ReadLine());

            Console.Write("Hasta Adı : ");
            patient.FirstName = Console.ReadLine();

            Console.Write("Hasta Soyadı : ");
            patient.LastName = Console.ReadLine();

            Console.Write("Hasta Telefon Numarası : ");
            patient.Phone = Console.ReadLine();

            Console.Write("Hasta Doğum Tarihi (yyyy-MM-dd) : ");
            patient.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Hasta Cinsiyeti : ");
            patient.Gender = Console.ReadLine();

            service.AddPatient(patient);

            Console.WriteLine("\nHasta Başarıyla Eklendi!");

        }

        static void ListPatients(PatientService service)
        {
            Console.Clear();
            var patients = service.GetAllPatients();

            Console.WriteLine("HASTA LİSTESİ");
            Console.WriteLine("------------\n");

            foreach (var p in patients)
            {
                Console.WriteLine($"Hasta ID : {p.PatientId}\n" +
                    $"Hasta Adı Soyadı : {p.FirstName} {p.LastName}\n" +
                    $"Hasta Telefon Numarası : {p.Phone}\n" +
                    $"Hasta Doğum Tarihi : {p.BirthDate}\n" +
                    $"Hasta Cinsiyeti : {p.Gender}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
        }

        static void UpdatePatient(PatientService service)
        {
            Console.Clear();
            Console.WriteLine("HASTA GÜNCELLEME");
            Console.WriteLine("---------------\n");

            Console.Write("Hasta Id Numarası : ");
            int id = int.Parse(Console.ReadLine());

            Patient patient = new Patient();
            patient.PatientId = id;

            Console.Write("Hasta Adı : ");
            patient.FirstName = Console.ReadLine();

            Console.Write("Hasta Soyadı : ");
            patient.LastName = Console.ReadLine();

            Console.Write("Hasta Telefon Numarası : ");
            patient.Phone = Console.ReadLine();

            Console.Write("Hasta Doğum Tarihi (yyyy-MM-dd) : ");
            patient.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Hasta Cinsiyeti : ");
            patient.Gender = Console.ReadLine();

            service.UpdatePatient(patient);

            Console.WriteLine("\nHasta Başarıyla Güncellendi!");

        }

        static void DeletePatient(PatientService service)
        {
            Console.Clear();
            Console.WriteLine("HASTA SİLME");
            Console.WriteLine("----------\n");

            Console.Write("Hasta Id Numarası : ");
            int id = int.Parse(Console.ReadLine());

            service.DeletePatient(id);

            Console.WriteLine("\nHasta Başarıyla Silindi!");
        }


        static void AddDoctor(DoctorService service)
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("DOKTOR EKLEME");
            Console.WriteLine("------------\n");

            Console.Write("Doktor Id : ");
            doctor.DoctorId = int.Parse(Console.ReadLine());

            Console.Write("Doktor Adı : ");
            doctor.FirstName = Console.ReadLine();

            Console.Write("Doktor Soyadı : ");
            doctor.LastName = Console.ReadLine();

            Console.Write("Departman Id : ");
            doctor.DepartmentId = int.Parse(Console.ReadLine());

            service.AddDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Eklendi!");
        }

        static void ListDoctors(DoctorService service)
        {
            Console.Clear();
            var doctors = service.GetAllDoctors();

            Console.WriteLine("Doktor LİSTESİ");
            Console.WriteLine("------------\n");

            foreach (var d in doctors)
            {
                Console.WriteLine($"Doktor ID : {d.DoctorId}\n" +
                    $"Doktor Adı Soyadı : {d.FirstName} {d.LastName}\n" +
                    $"Doktor Departman Id : {d.DepartmentId}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
        }

        static void UpdateDoctor(DoctorService service)
        {
            Console.Clear();
            Console.WriteLine("DOKTOR GÜNCELLEME");
            Console.WriteLine("----------------\n");

            Console.Write("Doktor Id Numarası : ");
            int id = int.Parse(Console.ReadLine());

            Doctor doctor = new Doctor();
            doctor.DoctorId = id;

            Console.Write("Doktor Adı : ");
            doctor.FirstName = Console.ReadLine();

            Console.Write("Doktor Soyadı : ");
            doctor.LastName = Console.ReadLine();

            Console.Write("Doktor Departman Id : ");
            doctor.DepartmentId = int.Parse(Console.ReadLine());

            service.UpdateDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Güncellendi!");
        }

        static void DeleteDoctor(DoctorService service)
        {
            Console.Clear();
            Console.WriteLine("DOKTOR SİLME");
            Console.WriteLine("-----------\n");

            Console.Write("Doktor Id Numarası : ");
            int id = int.Parse(Console.ReadLine());

            service.DeleteDoctor(id);

            Console.WriteLine("\nDoktor Başarıyla Silindi!");
        }



        public static void Clear()
        {
            Console.WriteLine("Devam etmek için bir tuşa basınız...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
