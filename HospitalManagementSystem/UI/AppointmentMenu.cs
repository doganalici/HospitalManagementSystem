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
    public class AppointmentMenu
    {
        private AppointmentService _appointmentService;
        private PatientService _patientService;
        private DoctorService _doctorService;

        public AppointmentMenu(AppointmentService appointmentService, PatientService patientService, DoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public void AddAppointment()
        {
            Console.Clear();
            Appointment appointment = new Appointment();
            Console.WriteLine("RANDEVU EKLEME");
            Console.WriteLine("--------------\n");

            if (_patientService.GetAllPatients().Count == 0)
            {
                Console.WriteLine("Önce hasta eklemelisiniz!");
                return;
            }

            if (_doctorService.GetAllDoctors().Count == 0)
            {
                Console.WriteLine("Önce doktor eklemelisiniz!");
                return;
            }

            ShowPatientsForSelection();
            int patientId;
            while (true)
            {
                patientId = InputHelper.ReadInt("Hasta Id : ");
                if (_patientService.PatientExists(patientId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Hasta Id! Lütfen geçerli bir hasta Id giriniz.");
            }
            appointment.PatientId = patientId;


            ShowDoctorsForSelection();
            int doctorId;
            while (true)
            {
                doctorId = InputHelper.ReadInt("Doktor Id : ");
                if (_doctorService.DoctorExists(doctorId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Doktor Id! Lütfen geçerli bir doktor Id giriniz.");
            }
            appointment.DoctorId = doctorId;

            appointment.AppointmentDate = InputHelper.ReadDateTime("Randevu Tarihi (Gün.Ay.Yıl Saat:Dakika → dd.MM.yyyy HH:mm) : ");

            appointment.Status = true;

            string result = _appointmentService.AddAppointment(appointment);
            if (result == "OK")
            {
                Console.WriteLine("\nRandevu Başarıyla Eklendi!");
            }
            else
            {
                Console.WriteLine($"Hata : {result}");
            }


        }
        public void ListAppointments()
        {
            Console.Clear();
            var appointments = _appointmentService.GetAllAppointments();
            Console.WriteLine("RANDEVU LİSTESİ");
            Console.WriteLine("---------------\n");

            if (appointments.Count == 0)
            {
                Console.WriteLine("Henüz bir randevu eklenmedi.");
            }
            else
            {
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
        }

        public void ShowAppointmentsForSelection()
        {
            var appointments = _appointmentService.GetAllAppointments();
            Console.WriteLine("\nMEVCUT RANDEVULAR ;");
            ;
            foreach (var a in appointments)
            {
                Console.WriteLine($"{a.AppointmentId} - Hasta ID: {a.PatientId}\n" +
                    $" Doktor ID: {a.DoctorId}\n" +
                    $" Tarih: {a.AppointmentDate:dd.MM.yyyy HH:mm}");
            }
            Console.WriteLine();
        }
        public void UpdateAppointment()
        {
            Console.Clear();
            Console.WriteLine("RANDEVU GÜNCELLEME");
            Console.WriteLine("------------------\n");

            ShowAppointmentsForSelection();

            int id = InputHelper.ReadInt("Randevu Id : ");
            if (!_appointmentService.AppointmentExists(id))
            {
                Console.WriteLine("\nBöyle bir randevu bulunamadı!");
                return;
            }


            Appointment appointment = new Appointment();
            appointment.AppointmentId = id;

            int patientId;
            while (true)
            {
                patientId = InputHelper.ReadInt("Hasta Id : ");
                if (_patientService.PatientExists(patientId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Hasta Id! Lütfen geçerli bir hasta Id giriniz.");
            }
            appointment.PatientId = patientId;


            int doctorId;
            while (true)
            {
                doctorId = InputHelper.ReadInt("Doktor Id : ");
                if (_doctorService.DoctorExists(doctorId))
                {
                    break;
                }
                Console.WriteLine("Geçersiz Doktor Id! Lütfen geçerli bir doktor Id giriniz.");
            }
            appointment.DoctorId = doctorId;

            appointment.AppointmentDate = InputHelper.ReadDateTime("Randevu Tarihi (Gün.Ay.Yıl Saat:Dakika → dd.MM.yyyy HH:mm) : ");

            appointment.Status = InputHelper.ReadBool("Randevu Durumu (true/false): ");

            _appointmentService.UpdateAppointment(appointment);
            Console.WriteLine("\nRandevu Başarıyla Güncellendi!");

        }
        public void DeleteAppointment()
        {
            Console.Clear();
            Console.WriteLine("RANDEVU SİLME");
            Console.WriteLine("-------------\n");

            ShowAppointmentsForSelection();
            int id = InputHelper.ReadInt("Randevu Id : ");
            if (!_appointmentService.AppointmentExists(id))
            {
                Console.WriteLine("\nBöyle bir randevu bulunamadı!");
                return;
            }

            _appointmentService.DeleteAppointment(id);
            Console.WriteLine("\nRandevu Başarıyla Silindi!");

        }

        private void ShowPatientsForSelection()
        {
            var patients = _patientService.GetAllPatients();

            Console.WriteLine("\nMEVCUT HASTALAR:");

            if (patients.Count == 0)
            {
                Console.WriteLine("Henüz hasta yok.");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"{p.PatientId} - {p.FirstName} {p.LastName}");
            }

            Console.WriteLine();
        }

        private void ShowDoctorsForSelection()
        {
            var doctors = _doctorService.GetAllDoctors();

            Console.WriteLine("\nMEVCUT DOKTORLAR:");

            if (doctors.Count == 0)
            {
                Console.WriteLine("Henüz doktor yok.");
                return;
            }

            foreach (var d in doctors)
            {
                Console.WriteLine($"{d.DoctorId} - {d.FirstName} {d.LastName}");
            }

            Console.WriteLine();
        }

    }
}
