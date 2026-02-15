using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Helpers
{
    public class InputHelper
    {
            public static int ReadInt(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Hatalı giriş! Tekrar giriniz :  ");
            }
            return value;
        }
        public static DateTime ReadDate(string message)
        {
            DateTime date;

            Console.Write(message);

            while (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                Console.Write("Hatalı tarih! (Örnek: 15.02.2026): ");
            }
            return date;
        }
        public static DateTime ReadDateTime(string message)
        {
            DateTime dateTime;

            Console.Write(message);

            while (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime))
            {
                Console.Write("Hatalı tarih! (Örnek: 15.02.2026 10:30): ");
            }

            return dateTime;
        }
        public static bool ReadBool(string message)
        {
            bool value;

            Console.Write(message);

            while (!bool.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Hatalı giriş! (true/false): ");
            }

            return value;
        }

        public static string ReadString(string message)
        {
            string value;

            do
            {
                Console.Write(message);
                value = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(value));

            return value;
        }
    }
}


