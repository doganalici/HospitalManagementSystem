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
    public class PatientMenu
    {
        private PatientService _patientService;

        public PatientMenu(PatientService patientService)
        {
            _patientService = patientService;
        }

        public void AddPatient()
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

            _patientService.AddPatient(patient);

            Console.WriteLine("\nHasta Başarıyla Eklendi!");
        }

        public void ListPatients()
        {
            Console.Clear();
            var patients = _patientService.GetAllPatients();

            Console.WriteLine("HASTA LİSTESİ");
            Console.WriteLine("-------------\n");
            if (patients.Count == 0)
            {
                Console.WriteLine("Henüz bir hasta eklenmedi.");
            }
            else
            {
                foreach (var p in patients)
                {
                    Console.WriteLine($"Hasta ID : {p.PatientId}\n" +
                        $"Hasta Adı Soyadı : {(p.FirstName + " " + p.LastName).ToUpper()}\n" +
                        $"Hasta Telefon Numarası : {p.Phone}\n" +
                        $"Hasta Doğum Tarihi : {p.BirthDate:dd.MM.yyyy}\n" +
                        $"Hasta Cinsiyeti : {p.Gender}");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                }
            }
        }
        public void ShowPatientsForSelection()
        {
            var patients = _patientService.GetAllPatients();
            Console.WriteLine("\nMEVCUT HASTALAR ;");
            ;
            foreach (var p in patients)
            {
                Console.WriteLine($"{p.PatientId} - {(p.FirstName + " " + p.LastName).ToUpper()}\n" +
                    $"Telefon: {p.Phone}\n" +
                    $"Doğum Tarihi: {p.BirthDate:dd.MM.yyyy}\n" +
                    $"Cinsiyeti : {p.Gender}");
            }
            Console.WriteLine();
        }

        public void UpdatePatient()
        {
            Console.Clear();
            Console.WriteLine("HASTA GÜNCELLEME");
            Console.WriteLine("----------------\n");

            ShowPatientsForSelection();
            Patient patient = new Patient();

            int id = InputHelper.ReadInt("Hasta Id : ");
            if (!_patientService.PatientExists(id))
            {
                Console.WriteLine("\nBöyle bir hasta bulunamadı!");
                return;
            }
            patient.PatientId = id;

            patient.FirstName = InputHelper.ReadString("Hasta Adı : ");

            patient.LastName = InputHelper.ReadString("Hasta Soyadı : ");

            patient.Phone = InputHelper.ReadString("Hasta Telefon Numarası : ");

            patient.BirthDate = InputHelper.ReadDate("Hasta Doğum Tarihi (gg.AA.yyyy) : ");

            patient.Gender = InputHelper.ReadString("Hasta Cinsiyeti : ");

            _patientService.UpdatePatient(patient);

            Console.WriteLine("\nHasta Başarıyla Güncellendi!");

        }

        public void DeletePatient()
        {
            Console.Clear();
            Console.WriteLine("HASTA SİLME");
            Console.WriteLine("-----------\n");

            ShowPatientsForSelection();

            int id = InputHelper.ReadInt("Hasta Id : ");
            if (!_patientService.PatientExists(id))
            {
                Console.WriteLine("\nBöyle bir hasta bulunamadı!");
                return;
            }

            _patientService.DeletePatient(id);

            Console.WriteLine("\nHasta Başarıyla Silindi!");
        }
    }
}
