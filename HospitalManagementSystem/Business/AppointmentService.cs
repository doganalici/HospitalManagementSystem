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
            //Hasta var mı?
            if (!_patientService.PatientExists(appointment.PatientId))
            {
                return "Hasta Bulunamadı"; // Hasta bulunamadı, randevu eklenmedi
            }

            //Doktor var mı?
            if (!_doctorService.DoctorExists(appointment.DoctorId))
            {
                return "Doktor Bulunamadı"; // Doktor bulunamadı, randevu eklenmedi
            }

            bool conflict = _appointments.Any(a => a.DoctorId == appointment.DoctorId && a.AppointmentDate == appointment.AppointmentDate);
            if (conflict)
            {
                return "Bu doktor bu saatte dolu";
            }
            appointment.AppointmentId = _idCounter++;
            _appointments.Add(appointment);
            return "OK";
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments;
        }
        public void UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _appointments.FirstOrDefault(x => x.AppointmentId == appointment.AppointmentId);

            if (existingAppointment != null)
            {
                existingAppointment.PatientId = appointment.PatientId;
                existingAppointment.DoctorId = appointment.DoctorId;
                existingAppointment.AppointmentDate = appointment.AppointmentDate;
                existingAppointment.Status = appointment.Status;
            }
        }
        public void DeleteAppointment(int appointmentId)
        {
            var appointment = _appointments.FirstOrDefault(x => x.AppointmentId == appointmentId);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
        }
    }
}
