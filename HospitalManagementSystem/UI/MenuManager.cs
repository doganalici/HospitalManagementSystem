using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System.Collections.Generic;
using System;

namespace HospitalManagementSystem.UI
{
    public class MenuManager
    {
        private PatientService _patientService;
        private DoctorService _doctorService;
        private AppointmentService _appointmentService;

        public MenuManager()
        {
            _patientService = new PatientService();
            _doctorService = new DoctorService();
            _appointmentService =
                new AppointmentService(_patientService, _doctorService);
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                ShowHeader();
                ShowMenu();

                Console.Write("\nSeçiminiz: ");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Hatalı giriş! Tekrar gir: ");
                }

                switch (option)
                {
                    case 1:
                        AddPatient(_patientService);
                        Clear();
                        break;

                    case 2:
                        ListPatients(_patientService);
                        Clear();
                        break;

                    case 3:
                        UpdatePatient(_patientService);
                        Clear();
                        break;

                    case 4:
                        DeletePatient(_patientService);
                        Clear();
                        break;

                    case 5:
                        AddDoctor(_doctorService);
                        Clear();
                        break;

                    case 6:
                        ListDoctors(_doctorService);
                        Clear();
                        break;

                    case 7:
                        UpdateDoctor(_doctorService);
                        Clear();
                        break;

                    case 8:
                        DeleteDoctor(_doctorService);
                        Clear();
                        break;

                    case 9:
                        AddAppointment(_appointmentService);
                        Clear();
                        break;

                    case 10:
                        ListAppointments(_appointmentService);
                        Clear();
                        break;

                    case 11:
                        UpdateAppointment(_appointmentService);
                        Clear();
                        break;

                    case 12:
                        DeleteAppointment(_appointmentService);
                        Clear();
                        break;

                    case 13:
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

            Console.WriteLine("13 - Çıkış");
        }

        public static void Clear()
        {
            Console.WriteLine("\nDevam etmek için bir tuşa basınız...");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddPatient(PatientService service)
        {
            Console.Clear();
            Patient patient = new Patient();
            Console.WriteLine("HASTA EKLEME");
            Console.WriteLine("------------\n");

            patient.FirstName = InputHelper.ReadString("Hasta Adı : ");

            patient.LastName = InputHelper.ReadString("Hasta Soyadı : ");

            patient.Phone = InputHelper.ReadString("Hasta Telefon Numarası : ");

            patient.BirthDate = InputHelper.ReadDate("Hasta Doğum Tarihi (gg.AA.yyyy) : ");

            patient.Gender = InputHelper.ReadString("Hasta Cinsiyeti : ");

            service.AddPatient(patient);

            Console.WriteLine("\nHasta Başarıyla Eklendi!");
        }

        private void ListPatients(PatientService service)
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
                    $"Hasta Doğum Tarihi : {p.BirthDate:dd.MM.yyyy}\n" +
                    $"Hasta Cinsiyeti : {p.Gender}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
        }

        private void UpdatePatient(PatientService service)
        {
            Console.Clear();
            Console.WriteLine("HASTA GÜNCELLEME");
            Console.WriteLine("---------------\n");
            Patient patient = new Patient();

            patient.PatientId = InputHelper.ReadInt("Hasta Id : ");

            patient.FirstName = InputHelper.ReadString("Hasta Adı : ");

            patient.LastName = InputHelper.ReadString("Hasta Soyadı : ");

            patient.Phone = InputHelper.ReadString("Hasta Telefon Numarası : ");

            patient.BirthDate = InputHelper.ReadDate("Hasta Doğum Tarihi (gg.AA.yyyy) : ");

            patient.Gender = InputHelper.ReadString("Hasta Cinsiyeti : ");

            service.UpdatePatient(patient);

            Console.WriteLine("\nHasta Başarıyla Güncellendi!");

        }

        private void DeletePatient(PatientService service)
        {
            Console.Clear();
            Console.WriteLine("HASTA SİLME");
            Console.WriteLine("----------\n");

            int id = InputHelper.ReadInt("Hasta Id : ");

            service.DeletePatient(id);

            Console.WriteLine("\nHasta Başarıyla Silindi!");
        }

        private void AddDoctor(DoctorService service)
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("DOKTOR EKLEME");
            Console.WriteLine("------------\n");

            doctor.FirstName = InputHelper.ReadString("Doktor Adı : ");

            doctor.LastName = InputHelper.ReadString("Doktor Soyadı : ");

            doctor.DepartmentId = InputHelper.ReadInt("Doktor Departman Id : ");

            service.AddDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Eklendi!");
        }

        private void ListDoctors(DoctorService service)
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

        private void UpdateDoctor(DoctorService service)
        {
            Console.Clear();
            Console.WriteLine("DOKTOR GÜNCELLEME");
            Console.WriteLine("----------------\n");

            int id = InputHelper.ReadInt("Doktor Id : ");

            Doctor doctor = new Doctor();
            doctor.DoctorId = id;

            doctor.FirstName = InputHelper.ReadString("Doktor Adı : ");

            doctor.LastName = InputHelper.ReadString("Doktor Soyadı : ");

            doctor.DepartmentId = InputHelper.ReadInt("Doktor Departman Id : ");

            service.UpdateDoctor(doctor);

            Console.WriteLine("\nDoktor Başarıyla Güncellendi!");
        }

        private void DeleteDoctor(DoctorService service)
        {
            Console.Clear();
            Console.WriteLine("DOKTOR SİLME");
            Console.WriteLine("-----------\n");

            int id = InputHelper.ReadInt("Doktor Id : ");

            service.DeleteDoctor(id);

            Console.WriteLine("\nDoktor Başarıyla Silindi!");
        }

        private void AddAppointment(AppointmentService service)
        {
            Console.Clear();
            Appointment appointment = new Appointment();
            Console.WriteLine("RANDEVU EKLEME");
            Console.WriteLine("--------------\n");

            appointment.PatientId = InputHelper.ReadInt("Hasta Id : ");

            appointment.DoctorId = InputHelper.ReadInt("Doktor Id : ");

            appointment.AppointmentDate = InputHelper.ReadDateTime("Randevu Tarihi (Gün.Ay.Yıl Saat:Dakika → dd.MM.yyyy HH:mm) : ");

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
        private void ListAppointments(AppointmentService service)
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
                    $"Randevu Tarihi : {a.AppointmentDate:dd.MM.yyyy HH:mm}\n" +
                    $"Randevu Durumu : {(a.Status ? "Aktif" : "Pasif")}");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            }
        }
        private void UpdateAppointment(AppointmentService service)
        {
            Console.Clear();
            Console.WriteLine("RANDEVU GÜNCELLEME");
            Console.WriteLine("-----------------\n");

            int id = InputHelper.ReadInt("Randevu Id : ");

            Appointment appointment = new Appointment();
            appointment.AppointmentId = id;

            appointment.PatientId = InputHelper.ReadInt("Hasta Id : ");

            appointment.DoctorId = InputHelper.ReadInt("Doktor Id : ");

            appointment.AppointmentDate = InputHelper.ReadDateTime("Randevu Tarihi (Gün.Ay.Yıl Saat:Dakika → dd.MM.yyyy HH:mm) : ");

            appointment.Status = InputHelper.ReadBool("Randevu Durumu (true/false): ");

            service.UpdateAppointment(appointment);
            Console.WriteLine("\nRandevu Başarıyla Güncellendi!");

        }
        private void DeleteAppointment(AppointmentService service)
        {
            Console.Clear();
            Console.WriteLine("RANDEVU SİLME");
            Console.WriteLine("-------------\n");

            int id = InputHelper.ReadInt("Randevu Id : ");

            service.DeleteAppointment(id);
            Console.WriteLine("\nRandevu Başarıyla Silindi!");

        }

    }
}
