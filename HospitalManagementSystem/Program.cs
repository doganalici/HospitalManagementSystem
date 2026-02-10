using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;
using System.Globalization;

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
            AppointmentService appointmentService = new AppointmentService(patientService, doctorService);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Menüden tuşlama yapınız\n");
                Console.WriteLine("1 - Hasta Ekle\n" +
                    "2 - Hastaları Listele\n" +
                    "3 - Hasta Güncelleme\n" +
                    "4 - Hasta Sil\n\n" +

                    "5 - Doktor Ekle\n" +
                    "6 - Doktorları Listele\n" +
                    "7 - Doktor Güncelle\n" +
                    "8 - Doktor Sil\n\n" +

                    "9 - Randevu Ekle\n" +
                    "10 - Randevuları Listele\n" +
                    "11 - Randevu Güncelle\n" +
                    "12 - Randevu Sil\n\n" +

                    "13 - Çıkış");

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
                        Console.Clear();
                        AddAppointment(appointmentService);
                        Clear();
                        break;
                    case 10:
                        Console.Clear();
                        ListAppointments(appointmentService);
                        Clear();
                        break;
                    case 11:
                        Console.Clear();
                        UpdateAppointment(appointmentService);
                        Clear();
                        break;
                    case 12:
                        Console.Clear();
                        DeleteAppointment(appointmentService);
                        Clear();
                        break;


                    case 13:
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

            Console.Write("Hasta Adı : ");
            patient.FirstName = Console.ReadLine();

            Console.Write("Hasta Soyadı : ");
            patient.LastName = Console.ReadLine();

            Console.Write("Hasta Telefon Numarası : ");
            patient.Phone = Console.ReadLine();

            Console.Write("Hasta Doğum Tarihi (gg.AA.yyyy) : ");
            DateTime birthDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
            {
                Console.Write("Hatalı tarih! Örnek: 15.02.2026 gibi tekrar girin: ");
            }
            patient.BirthDate = birthDate;

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

            Console.Write("Hasta Doğum Tarihi (gg.AA.yyyy) : ");
            DateTime birthDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
            {
                Console.Write("Hatalı tarih! Örnek: 15.02.2026 gibi tekrar girin: ");
            }
            patient.BirthDate = birthDate;

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

            Console.Write("Doktor Adı : ");
            doctor.FirstName = Console.ReadLine();

            Console.Write("Doktor Soyadı : ");
            doctor.LastName = Console.ReadLine();

            Console.Write("Departman Id : ");
            int departmentId;
            while (!int.TryParse(Console.ReadLine(), out departmentId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            doctor.DepartmentId = departmentId;

            service.AddDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Eklendi!");
        }

        static void ListDoctors(DoctorService service)
        {
            Console.Clear();
            var doctors = service.GetAllDoctors();

            Console.WriteLine("Doktor LİSTESİ");
            Console.WriteLine("-------------\n");

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
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }

            Doctor doctor = new Doctor();
            doctor.DoctorId = id;

            Console.Write("Doktor Adı : ");
            doctor.FirstName = Console.ReadLine();

            Console.Write("Doktor Soyadı : ");
            doctor.LastName = Console.ReadLine();

            Console.Write("Doktor Departman Id : ");
            int departmentId;
            while (!int.TryParse(Console.ReadLine(), out departmentId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            doctor.DepartmentId = departmentId;

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


        static void AddAppointment(AppointmentService service)
        {
            Console.Clear();
            Appointment appointment = new Appointment();
            Console.WriteLine("RANDEVU EKLEME");
            Console.WriteLine("--------------\n");

            Console.Write("Hasta Id : ");
            int patientId;
            while (!int.TryParse(Console.ReadLine(), out patientId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            appointment.PatientId = patientId;

            Console.Write("Doktor Id : ");
            int doctorId;
            while (!int.TryParse(Console.ReadLine(), out doctorId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            appointment.DoctorId = doctorId;

            Console.Write("Randevu Tarihi (gg.AA.yyyy SS:dd) : ");
            DateTime appointmentDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out appointmentDate))
            {
                Console.Write("Hatalı tarih! Örnek: 15.02.2026 10:30 gibi tekrar girin: ");
            }
            appointment.AppointmentDate = appointmentDate;

            appointment.Status = true;

            string result = service.AddAppointment(appointment);
            if (result == "OK")
            {
                Console.WriteLine("\nRandevu Başarıyla Eklendi!");
            }
            else
            {
                Console.WriteLine($"Hata : {result}");
            }


        }
        static void ListAppointments(AppointmentService service)
        {
            Console.Clear();
            var appointments = service.GetAllAppointments();
            Console.WriteLine("RANDEVU LİSTESİ");
            Console.WriteLine("--------------\n");

            foreach (var a in appointments)
            {
                Console.WriteLine($"Randevu ID : {a.AppointmentId}\n" +
                    $"Hasta ID : {a.PatientId}\n" +
                    $"Doktor ID : {a.DoctorId}\n" +
                    $"Randevu Tarihi : {a.AppointmentDate}\n" +
                    $"Randevu Durumu : {(a.Status ? "Aktif" : "Pasif")}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
        }
        static void UpdateAppointment(AppointmentService service)
        {
            Console.Clear();
            Console.WriteLine("RANDEVU GÜNCELLEME");
            Console.WriteLine("-----------------\n");

            Console.Write("Randevu Id Numarası : ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }

            Appointment appointment = new Appointment();
            appointment.AppointmentId = id;

            Console.Write("Hasta Id : ");
            int patientId;
            while (!int.TryParse(Console.ReadLine(), out patientId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            appointment.PatientId = patientId;

            Console.Write("Doktor Id : ");
            int doctorId;
            while (!int.TryParse(Console.ReadLine(), out doctorId))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }
            appointment.DoctorId = doctorId;

            Console.Write("Randevu Tarihi (gg.AA.yyyy SS:dd) : ");
            DateTime appointmentDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out appointmentDate))
            {
                Console.Write("Hatalı tarih! Örnek: 15.02.2026 10:30 gibi tekrar girin: ");
            }
            appointment.AppointmentDate = appointmentDate;

            Console.Write("Randevu Durumu (Aktif için true, Pasif için false) : ");
            bool status;
            while (!bool.TryParse(Console.ReadLine(), out status))
            {
                Console.Write("Hatalı giriş! Lütfen 'true' veya 'false' giriniz: ");
            }
            appointment.Status = status;

            service.UpdateAppointment(appointment);
            Console.WriteLine("\nRandevu Başarıyla Güncellendi!");

        }
        static void DeleteAppointment(AppointmentService service)
        {
            Console.Clear();
            Console.WriteLine("RANDEVU SİLME");
            Console.WriteLine("-------------\n");

            Console.Write("Randevu Id Numarası : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Hatalı giriş! Lütfen sayı giriniz: ");
            }

            service.DeleteAppointment(id);
            Console.WriteLine("\nRandevu Başarıyla Silindi!");

        }

        public static void Clear()
        {
            Console.WriteLine("Devam etmek için bir tuşa basınız...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
