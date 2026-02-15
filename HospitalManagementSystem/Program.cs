using HospitalManagementSystem.Business;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuManager menu = new MenuManager();
            menu.Run();
        }
    }
}
