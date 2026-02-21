using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business
{
    public class AppointmentService
    {
        private List<Appointment> _appointments;
        private string _filePath = "appointments.json";
        private PatientService _patientService;
        private DoctorService _doctorService;


        private int _idCounter = 1;

        public AppointmentService(PatientService patientService, DoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;

            _appointments = JsonHelper.LoadFromFile<Appointment>(_filePath);

            if (_appointments.Any())
                _idCounter = _appointments.Max(x => x.AppointmentId) + 1;
        }

        public string AddAppointment(Appointment appointment)
        {
            var doctor = _doctorService.GetById(appointment.DoctorId);
            if (appointment.AppointmentDate <= DateTime.Now)
            {
                return "Geçmiş tarihe randevu oluşturulamaz!";
            }

            if (doctor == null)
                return "Seçilen doktor bulunamadı.";

            if (!doctor.IsActive)
                return "Seçilen doktor aktif değil.";

            // Hasta var mı kontrolü
            if (!_patientService.PatientExists(appointment.PatientId))
            {
                return "Seçilen hasta bulunamadı.";
            }
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

            DateTime lunchStart = new DateTime(newStart.Year, newStart.Month, newStart.Day, 12, 00, 0);
            DateTime lunchEnd = new DateTime(newStart.Year, newStart.Month, newStart.Day, 13, 0, 0);

            if (newStart < lunchEnd && newEnd > lunchStart)
            {
                return "12:00 - 13:00 arası öğle molasıdır. Bu saatlerde randevu alınamaz.";
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
            JsonHelper.SaveToFile(_filePath, _appointments);
            return "OK";
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }
        public string UpdateAppointment(Appointment appointment)
        {
            // Doktor var mı kontrolü
            if (!_doctorService.DoctorExists(appointment.DoctorId))
            {
                return "Seçilen doktor bulunamadı.";
            }

            // Hasta var mı kontrolü
            if (!_patientService.PatientExists(appointment.PatientId))
            {
                return "Seçilen hasta bulunamadı.";
            }
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

            DateTime lunchStart = new DateTime(newStart.Year, newStart.Month, newStart.Day, 12, 00, 0);
            DateTime lunchEnd = new DateTime(newStart.Year, newStart.Month, newStart.Day, 13, 0, 0);

            if (newStart < lunchEnd && newEnd > lunchStart)
            {
                return "12:00 - 13:00 arası öğle molasıdır. Bu saatlerde randevu alınamaz.";
            }
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
            JsonHelper.SaveToFile(_filePath, _appointments);
            return "OK";
        }
        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _appointments.FirstOrDefault(x => x.AppointmentId == appointmentId);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
            JsonHelper.SaveToFile(_filePath, _appointments);
        }
        public bool AppointmentExists(int appointmentId)
        {
            return _appointments.Any(x => x.AppointmentId == appointmentId);
        }

        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date)
        {
            List<DateTime> availableSlots = new List<DateTime>();

            // Hafta sonu kontrolü
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
            {
                return availableSlots;
            }

            DateTime workStart = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
            DateTime workEnd = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);

            DateTime lunchStart = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
            DateTime lunchEnd = new DateTime(date.Year, date.Month, date.Day, 13, 0, 0);

            // O doktora ait o günkü aktif randevular
            var doctorAppointments = _appointments
                .Where(a => a.DoctorId == doctorId
                            && a.Status
                            && a.AppointmentDate.Date == date.Date)
                .ToList();

            DateTime currentSlot = workStart;

            while (currentSlot < workEnd)
            {
                DateTime slotEnd = currentSlot.AddMinutes(15);


                if (date.Date == DateTime.Today && slotEnd <= DateTime.Now)
                {
                    currentSlot = currentSlot.AddMinutes(15);
                    continue;
                }
                if (currentSlot < lunchEnd && slotEnd > lunchStart)
                {
                    currentSlot = currentSlot.AddMinutes(15);
                    continue;
                }

                bool isBusy = doctorAppointments.Any(a =>
                {
                    DateTime existingStart = a.AppointmentDate;
                    DateTime existingEnd = existingStart.AddMinutes(15);

                    return currentSlot < existingEnd && existingStart < slotEnd;
                });

                if (!isBusy)
                {
                    availableSlots.Add(currentSlot);
                }

                currentSlot = currentSlot.AddMinutes(15);
            }

            return availableSlots;
        }
    }
}
