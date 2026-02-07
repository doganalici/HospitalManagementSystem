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

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
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
