using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class AppointmentService
    {
        private List<Appointment> _appointments = new List<Appointment>();
        private PatientService _patientService;
        private DoctorService _doctorService;


        private int _idCounter = 1;

        public AppointmentService(PatientService patientService, DoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public string AddAppointment(Appointment appointment)
        {
            DateTime newStart = appointment.AppointmentDate;
            DateTime newEnd = newStart.AddMinutes(15);

            // 15 dakikalık slot kontrolü
            if (appointment.AppointmentDate.Minute % 15 != 0 || appointment.AppointmentDate.Second != 0)
            {
                return "Randevu sadece 15 dakikalık zaman dilimlerinde alınabilir (00, 15, 30, 45).";
            }

            if (appointment.AppointmentDate.DayOfWeek == DayOfWeek.Saturday || appointment.AppointmentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return "Randevu günleri sadece hafta içi olabilir!";
            }

            // Çalışma saatleri kontrolü
            DateTime workStart = new DateTime(newStart.Year, newStart.Month, newStart.Day, 9, 0, 0);
            DateTime workEnd = new DateTime(newStart.Year, newStart.Month, newStart.Day, 17, 0, 0);

            if (newStart < workStart || newEnd > workEnd)
            {
                return "Randevu sadece 09:00 - 17:00 çalışma saatleri içinde olmalıdır!";
            }

            // Doktor çakışma kontrolü
            bool doctorBusy = _appointments.Any(a =>
            {
                if (a.DoctorId != appointment.DoctorId || !a.Status)

                    return false;
                DateTime existingStart = a.AppointmentDate;
                DateTime existingEnd = existingStart.AddMinutes(15);

                return newStart < existingEnd && existingStart < newEnd;
            });

            if (doctorBusy)
            {
                return "Bu doktor seçilen tarih ve saatte dolu!";
            }

            // Hasta çakışma kontrolü
            bool patientBusy = _appointments.Any(a =>
            {
                if (a.PatientId != appointment.PatientId || !a.Status)
                    return false;
                DateTime existingStart = a.AppointmentDate;
                DateTime existingEnd = existingStart.AddMinutes(15);
                return newStart < existingEnd && existingStart < newEnd;
            });

            if (patientBusy)
            {
                return "Bu hasta seçilen tarih ve saatte başka bir randevuya sahip!";
            }

            appointment.AppointmentId = _idCounter++;
            _appointments.Add(appointment);
            return "OK";
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }
        public string UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _appointments
                .FirstOrDefault(x => x.AppointmentId == appointment.AppointmentId);

            if (existingAppointment == null)
                return "Randevu bulunamadı.";

            if (appointment.AppointmentDate.DayOfWeek == DayOfWeek.Saturday
    || appointment.AppointmentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return "Randevu günleri sadece hafta içi olabilir!";
            }
            DateTime newStart = appointment.AppointmentDate;
            DateTime newEnd = newStart.AddMinutes(15);

            // 15 dakika kontrolü
            if (appointment.AppointmentDate.Minute % 15 != 0 || appointment.AppointmentDate.Second != 0)
                return "Randevu sadece 15 dakikalık zaman dilimlerinde alınabilir.";

            // Çalışma saatleri kontrolü
            DateTime workStart = new DateTime(newStart.Year, newStart.Month, newStart.Day, 9, 0, 0);
            DateTime workEnd = new DateTime(newStart.Year, newStart.Month, newStart.Day, 17, 0, 0);

            if (newStart < workStart || newEnd > workEnd)
                return "Randevu çalışma saatleri içinde olmalıdır.";

            // Doktor çakışma kontrolü (kendisi hariç)
            bool doctorBusy = _appointments.Any(a =>
            {
                if (a.AppointmentId == appointment.AppointmentId)
                    return false;

                if (a.DoctorId != appointment.DoctorId || !a.Status)
                    return false;

                DateTime existingStart = a.AppointmentDate;
                DateTime existingEnd = existingStart.AddMinutes(15);

                return newStart < existingEnd && existingStart < newEnd;
            });

            if (doctorBusy)
                return "Bu doktor seçilen zaman aralığında dolu!";

            // Hasta çakışma kontrolü (kendisi hariç)
            bool patientBusy = _appointments.Any(a =>
            {
                if (a.AppointmentId == appointment.AppointmentId)
                    return false;

                if (a.PatientId != appointment.PatientId || !a.Status)
                    return false;

                DateTime existingStart = a.AppointmentDate;
                DateTime existingEnd = existingStart.AddMinutes(15);

                return newStart < existingEnd && existingStart < newEnd;
            });

            if (patientBusy)
                return "Bu hasta seçilen zaman aralığında başka bir randevuya sahip!";

            // Güncelleme
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.Status = appointment.Status;

            return "OK";
        }
        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _appointments.FirstOrDefault(x => x.AppointmentId == appointmentId);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
        }
        public bool AppointmentExists(int appointmentId)
        {
            return _appointments.Any(x => x.AppointmentId == appointmentId);
        }
    }
}
